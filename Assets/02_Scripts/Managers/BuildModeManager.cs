using System.Collections.Generic;
using UnityEngine;

public class BuildModeManager : MonoBehaviour
{
    public bool IsBuildingMode { get; private set; }
    private BuildData currentBuildData;

    private GameObject previewObject;
    private Renderer[] previewRenderers;

    [Header("Preview Settings")]
    public float rotateSpeed = 50f;
    public LayerMask groundMask;
    public LayerMask obstructionMask;

    private Material previewValidMat;
    private Material previewInvalidMat;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    //
    // 1) 빌드 모드 진입
    //
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

        // 1) 기존 프리뷰가 있으면 제거 (중복 생성 방지)
        if (previewObject != null)
        {
            Destroy(previewObject);
            previewObject = null;
        }

        currentBuildData = data;

        Inventory inv = GameManager.Instance.characterManager.player.inventory;

        // 2) 자원 부족 체크
        if (!CheckResourceShortage(data, inv, out var shortfall))
        {
            Debug.Log("해당 건물을 만드는 자원이 부족해 Preview 생성 실패");

            // TODO: UI 자원부족 
            return;
        }

        // 3) 자원 소비 (프리뷰를 꺼내는 순간 자원 사용)
        foreach (var req in data.requirements)
        {
            inv.ConsumeMultiple(req.item, req.amount);
        }

        // 4) 프리뷰 생성
        CreatePreviewObject(data);

        Debug.Log($"'{data.displayName}' 프리뷰 생성 및 자원 소비");
    }



    // 
    // 2) 빌드 모드 나가기
    //
    public void ExitBuildMode()
    {
        IsBuildingMode = false;


        if (previewObject != null)
            Destroy(previewObject);

        currentBuildData = null;

        // TODO: UI 나가기 버튼? or 지금 상태에서는 B를 한번 더 누르면 종료됨.
        
    }

    // 
    // 3) Preview 생성
    // 
    private void CreatePreviewObject(BuildData data)
    {
        previewObject = Instantiate(data.previewPrefab);
        previewRenderers = previewObject.GetComponentsInChildren<Renderer>();

        //리소스 폴더의 투명 머터리얼 가져옴 (설치가능 시 초록색 / 불가능 시 붉은 색)
        previewValidMat = Resources.Load<Material>("TestMaterial/PreviewValid");
        previewInvalidMat = Resources.Load<Material>("TestMaterial/PreviewInvalid");

        foreach (var rend in previewRenderers)
            rend.material = previewValidMat;
    }

    //
    // 프리뷰 들고 있는 상태에서 이동시 위치 업데이트
    //
    private void Update()
    {
        if (!IsBuildingMode) return;

        UpdatePreviewPosition();
    }

    private void UpdatePreviewPosition()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        // Ground Layer 추가 예정

        if (Physics.Raycast(ray, out RaycastHit hit, 30f, groundMask)) 
        {
            if (previewObject == null) return;
            previewObject.transform.position = hit.point;

            bool valid = CheckPlacementValidity();
            UpdatePreviewMaterial(valid);
        }
    }

    // 
    // 4) 설치 가능 여부 검사
    // 
    private bool CheckPlacementValidity()
    {
        Bounds bounds = GetPreviewBounds();

        Collider[] hits = Physics.OverlapBox(
            bounds.center,
            bounds.extents,
            previewObject.transform.rotation,
            obstructionMask);

        return hits.Length == 0;
    }

    private Bounds GetPreviewBounds()
    {
        Bounds bounds = new Bounds(previewObject.transform.position, Vector3.zero);

        foreach (var rend in previewRenderers)
            bounds.Encapsulate(rend.bounds);

        return bounds;
    }

    private void UpdatePreviewMaterial(bool valid)
    {
        foreach (var rend in previewRenderers)
            rend.material = valid ? previewValidMat : previewInvalidMat;
    }

    // 
    // 5) 설치 시도
    // 
    public void TryPlaceStructure()
    {
        //  빌드모드가 아니면 설치 시도 무시
        if (!IsBuildingMode)
            return;

        //  프리뷰가 없으면 설치 불가 (카탈로그에서 선택 안 한 상태)
        if (previewObject == null)
        {
            Debug.LogWarning("[Build] 설치 불가: 프리뷰가 없습니다. 먼저 건축물을 선택하세요.");
            return;
        }

        //  설치 위치 체크 (충돌)
        if (!CheckPlacementValidity())
        {
            Debug.Log("[Build] 설치 불가: 충돌이 감지되었습니다.");
            return;
        }

        //  완성 건축물 생성
        Instantiate(
            currentBuildData.completePrefab,
            previewObject.transform.position,
            previewObject.transform.rotation
        );

        Debug.Log($"[Build] '{currentBuildData.displayName}' 설치 완료");

        //  빌드모드 종료 (프리뷰 삭제 + 상태 초기화 + UI 정리)
        ExitBuildMode();
    }


    // 
    // 6) 자원 부족 리스트 계산
    // 
    public bool CheckResourceShortage(BuildData data, Inventory inv,
        out Dictionary<ItemData, int> shortfall)
    {
        shortfall = new();

        foreach (var req in data.requirements)
        {
            int has = inv.Count(req.item);

            if (has < req.amount)
                shortfall[req.item] = req.amount - has;
        }

        return shortfall.Count == 0;
    }

    // 
    // 7) 회전 기능
    // 
    public void RotateLeft()
    {
        if (!IsBuildingMode) return;
        previewObject.transform.Rotate(Vector3.up, -rotateSpeed);
    }

    public void RotateRight()
    {
        if (!IsBuildingMode) return;
        previewObject.transform.Rotate(Vector3.up, rotateSpeed);
    }
}




