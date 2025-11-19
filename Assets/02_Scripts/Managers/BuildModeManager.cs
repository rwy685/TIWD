using System.Collections;
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

    // ────────────────────────────────────────────────
    // 1) Build Mode Entry
    // ────────────────────────────────────────────────
    public void EnterBuildMode(BuildData data)
    {
        if (IsBuildingMode)
            ExitBuildMode();

        IsBuildingMode = true;
        currentBuildData = data;

        CreatePreviewObject(data);

        // TODO: UI 담당자 요청
        // BuildUI.Instance.ShowBuildPanel(currentBuildData);
    }

    // ────────────────────────────────────────────────
    // 2) Build Mode Exit
    // ────────────────────────────────────────────────
    public void ExitBuildMode()
    {
        IsBuildingMode = false;

        if (previewObject != null)
            Destroy(previewObject);

        currentBuildData = null;

        // TODO: UI 담당자 요청
        // BuildUI.Instance.HideBuildPanel();
    }

    // ────────────────────────────────────────────────
    // 3) Preview 생성
    // ────────────────────────────────────────────────
    private void CreatePreviewObject(BuildData data)
    {
        previewObject = Instantiate(data.previewPrefab);
        previewRenderers = previewObject.GetComponentsInChildren<Renderer>();

        previewValidMat = Resources.Load<Material>("TestMaterial/PreviewValid");
        previewInvalidMat = Resources.Load<Material>("TestMaterial/PreviewInvalid");

        foreach (var rend in previewRenderers)
            rend.material = previewValidMat;
    }

    // ────────────────────────────────────────────────
    private void Update()
    {
        if (!IsBuildingMode) return;

        UpdatePreviewPosition();
    }

    private void UpdatePreviewPosition()
    {
        Ray ray = cam.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out RaycastHit hit, 30f, groundMask))
        {
            if (previewObject == null) return;
            previewObject.transform.position = hit.point;

            bool valid = CheckPlacementValidity();
            UpdatePreviewMaterial(valid);
        }
    }

    // ────────────────────────────────────────────────
    // 4) 설치 가능 여부 검사
    // ────────────────────────────────────────────────
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

    // ────────────────────────────────────────────────
    // 5) 설치 시도
    // ────────────────────────────────────────────────
    public void TryPlaceStructure()
    {
        if (!CheckPlacementValidity())
        {
            Debug.Log("설치 불가: 충돌 감지됨");
            return;
        }

        Inventory inv = GameManager.Instance.characterManager.player.inventory;

        // 1) 자원 부족 체크
        if (!CheckResourceShortage(currentBuildData, inv, out var shortfall))
        {
            // TODO: UI 담당자 요청
            // BuildUI.Instance.ShowShortage(shortfall);
            Debug.Log("설치 불가: 자원이 부족합니다.");
            return;
        }

        // 2) 자원 소비
        foreach (var req in currentBuildData.requirements)
            inv.ConsumeMultiple(req.item, req.amount);

        // 3) 완성 건물 생성
        Instantiate(
            currentBuildData.completePrefab,
            previewObject.transform.position,
            previewObject.transform.rotation
        );

        ExitBuildMode();
    }

    // ────────────────────────────────────────────────
    // 6) 자원 부족 리스트 계산
    // ────────────────────────────────────────────────
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

    // ────────────────────────────────────────────────
    // 7) 회전 기능
    // ────────────────────────────────────────────────
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




