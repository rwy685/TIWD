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

    //프리뷰 생성시 소모한 자원 기록
    private Dictionary<ItemData, int> consumedForPreview = new Dictionary<ItemData, int>();
    private void Awake()
    {
        
        previewController = new BuildPreviewController(groundMask, obstructionMask, rotateSpeed);
        resourceHandler = new BuildResourceHandler();
        placementSystem = new BuildPlacementSystem();
    }

    //
    //  빌드 모드 진입
    //  [UI 가이드] : 빌드 모드 패널 켜기/ BuildCatalog SO를 UI에 등록해 건축목록버튼(아이콘/이름/번호?) 할당
    public void EnterBuildMode()
    {
        IsBuildingMode = true;
    }

    public void SelectBuildData(BuildData data)
    {
        if (data == null)
        {
            Debug.LogWarning("[Build] SelectBuildData 호출됨, data = null.");
            return;
        }

        //  기존 프리뷰가 있으면 제거 (같은 프리뷰/ 다른 프리뷰 변경 시 자원 환불)
        if (previewController.HasPreview())
        {
            RefundPreviewResources();   
            previewController.DestroyPreview();
        }
        currentBuildData = data;

        Inventory inv = GameManager.Instance.characterManager.player.inventory;

        //  자원 부족 체크
        if (!resourceHandler.CheckResourceShortage(data, inv, out var shortfall))
        {
            Debug.Log("해당 건물을 만드는 자원이 부족해 Preview 생성 실패");

            //[UI 가이드] : 자원 부족 메시지 표시 / shortfall 딕셔너리에 어떤 자원이 몇 개 부족한지 저장해둠
            return;
        }

        //  다른 프리뷰 생성 시, 이전 소비 기록 제거
        consumedForPreview.Clear();

        // 자원 소비 + 소비 기록 저장
        foreach (var req in data.requirements)
        {
            inv.ConsumeMultiple(req.item, req.amount);
            consumedForPreview[req.item] = req.amount; // 기록 저장
        }

        //  프리뷰 생성
        previewController.CreatePreviewObject(data);

        Debug.Log($"'{data.displayName}' 프리뷰 생성 및 자원 소비");
    }

    //
    //  빌드 모드 나가기
    //
    public void ExitBuildMode()
    {
        IsBuildingMode = false;

        //[UI 가이드] : 빌드 모드 패널 비활성화 /  BuildCatalog SO를 UI도 끄기 

        previewController.DestroyPreview();

        RefundPreviewResources(); //설치 안하고 나갔을 때도 환불

        currentBuildData = null;
    }

    //프리뷰 취소시 자원 환불
    private void RefundPreviewResources()
    {
        if (consumedForPreview.Count == 0)
            return;

        Inventory inv = GameManager.Instance.characterManager.player.inventory;

        foreach (var pair in consumedForPreview)
            inv.AddItemToInventory(pair.Key, pair.Value);

        consumedForPreview.Clear();

        Debug.Log($"{currentBuildData}프리뷰 취소 → 소모 자원 환불 완료");
    }

    //
    // 프리뷰 위치 업데이트만 호출
    //
    private void Update()
    {
        if (!IsBuildingMode) return;

        previewController.UpdatePreviewPosition();
    }

    //
    // 5) 설치 시도
    //
    public void TryPlaceStructure()
    {
        if (!IsBuildingMode)
            return;

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

        // 완성 건축물 생성
        placementSystem.PlaceStructure(currentBuildData, previewController);

        Debug.Log($"[Build] '{currentBuildData.displayName}' 설치 완료");

    }

    //
    // 7) 회전 기능
    //
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






