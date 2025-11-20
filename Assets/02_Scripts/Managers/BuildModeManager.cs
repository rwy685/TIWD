using System.Collections.Generic;
using UnityEngine;

public class BuildModeManager : MonoBehaviour
{
    public bool IsBuildingMode { get; private set; }
    private BuildData currentBuildData;

    [Header("Preview Settings")]
    public float rotateSpeed = 50f;
    public LayerMask groundMask;
    public LayerMask obstructionMask;
    
    private BuildPreviewController previewController;
    private BuildResourceHandler resourceHandler;
    private BuildPlacementSystem placementSystem;

    private void Start()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            var player = GameManager.Instance.characterManager.player;
            if (player != null)
                cam = player.GetComponentInChildren<Camera>();
        }
        previewController = new BuildPreviewController(cam, groundMask, obstructionMask, rotateSpeed);
        resourceHandler = new BuildResourceHandler();
        placementSystem = new BuildPlacementSystem();
        
    }

    // =====================================================
    //  빌드 모드 진입
    // =====================================================
    //  [UI 가이드] : 빌드 모드 패널 켜기/ BuildCatalog SO를 UI에 등록해 건축목록버튼(아이콘/이름/번호?) 할당
    public void EnterBuildMode()
    {
        IsBuildingMode = true;

        // [UI] 빌드 모드 패널 켜기
        //if (UIManager.Instance != null)
        //    UIManager.Instance.OpenBuildUI();
    }

    public void SelectBuildData(BuildData data)
    {
        if (data == null) return;

        //  기존 프리뷰가 있으면 제거 (같은 프리뷰/ 다른 프리뷰 변경)
        if (previewController.HasPreview())
        {
            previewController.DestroyPreview();
        }
        currentBuildData = data;

        Inventory inv = GameManager.Instance.characterManager.player.inventory;
        //  자원 부족 체크
        if (!resourceHandler.CheckResourceShortage(data, inv, out var shortfall))
        {
            Debug.Log("자원 부족 - 프리뷰 생성 안됨");

            //[UI 가이드] : 자원 부족 메시지 표시 / shortfall 딕셔너리에 어떤 자원이 몇 개 부족한지 저장해둠
            return;
        }
        //  프리뷰 생성
        previewController.CreatePreviewObject(data);
    }

    // =====================================================
    //  빌드 모드 나가기
    // =====================================================
    public void ExitBuildMode()
    {
        IsBuildingMode = false;

        // [UI] 빌드 모드 패널 끄기
        //if (UIManager.Instance != null)
        //    UIManager.Instance.CloseBuildUI();

        previewController.DestroyPreview();

        currentBuildData = null;
    }

    // =====================================================
    // 프리뷰 위치 업데이트만 호출
    // =====================================================
    private void Update()
    {
        if (!IsBuildingMode) return;

        previewController.UpdatePreviewPosition();
    }

    // =====================================================
    // 설치 시도
    // =====================================================
    public void TryPlaceStructure()
    {
        if (!IsBuildingMode) return;

        if (!previewController.HasPreview())
        {
            Debug.LogWarning("[Build] 설치 불가: 프리뷰가 없습니다. 먼저 건축물을 선택하세요.");
            return;
        }
        if (!previewController.CheckPlacementValidity())
        {
            Debug.Log("[Build] 설치 불가: 충돌이 감지되었습니다.");
            return;
        }

        Inventory inv = GameManager.Instance.characterManager.player.inventory;

        // 한번 더 자원체크
        if (!resourceHandler.CheckResourceShortage(currentBuildData, inv, out var shortfall))
        {
            Debug.Log("[Build] 설치 불가: 자원이 부족합니다.");
            return;
        }

        // 자원 소비
        resourceHandler.ConsumeBuildResources(currentBuildData, inv);

        // 설치
        placementSystem.PlaceStructure(currentBuildData, previewController);

        //프리뷰 제거
        previewController.DestroyPreview();

        Debug.Log($"[Build] '{currentBuildData.displayName}' 설치 완료");
        currentBuildData = null;

    }

    // =====================================================
    // 7) 회전 기능
    // =====================================================
    public void RotateLeft()
    {
        if (!IsBuildingMode) return;
        previewController.Rotate(-1);
    }

    public void RotateRight()
    {
        if (!IsBuildingMode) return;
        previewController.Rotate(1);
    }
}






