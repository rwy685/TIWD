using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeManager : MonoBehaviour
{
    public bool IsBuildingMode { get; private set; }

    private BuildData currentBuildData;

    // Preview
    private GameObject previewObject;
    private Renderer[] previewRenderers;

    [Header("Preview Settings")]
    public float rotateSpeed = 50f;
    public LayerMask groundMask;        // 지면
    public LayerMask obstructionMask;   // 설치 불가 충돌 레이어

    private Material previewValidMat;
    private Material previewInvalidMat;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    // ────────────────────────────────────────────────
    // 1) 건축모드 진입
    // ────────────────────────────────────────────────
    public void EnterBuildMode(BuildData data)
    {
        if (IsBuildingMode)
            ExitBuildMode();

        IsBuildingMode = true;
        currentBuildData = data;

        CreatePreviewObject(data);

        // 필요하면 UI 켜기
        // BuildUI.Show()
    }

    // ────────────────────────────────────────────────
    // 2) 건축모드 종료
    // ────────────────────────────────────────────────
    public void ExitBuildMode()
    {
        IsBuildingMode = false;

        if (previewObject != null)
            Destroy(previewObject);

        currentBuildData = null;

        // 필요하면 UI 끄기
        // BuildUI.Hide()
    }

    // ────────────────────────────────────────────────
    // 3) 프리뷰 생성
    // ────────────────────────────────────────────────
    private void CreatePreviewObject(BuildData data)
    {
        previewObject = Instantiate(data.previewPrefab);

        previewRenderers = previewObject.GetComponentsInChildren<Renderer>();

        previewValidMat = Resources.Load<Material>("TestMaterial/PreviewValid");
        previewInvalidMat = Resources.Load<Material>("TestMaterial/PreviewInvalid");

        foreach (var rend in previewRenderers)
            rend.material = previewValidMat; // 기본값 설치 가능
    }

    // ────────────────────────────────────────────────
    // 4) Update - 프리뷰 위치 업데이트
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
            previewObject.transform.position = hit.point;

            bool valid = CheckPlacementValidity();
            UpdatePreviewMaterial(valid);
        }
    }

    // ────────────────────────────────────────────────
    // 5) 설치 가능 여부 검사
    // ────────────────────────────────────────────────
    private bool CheckPlacementValidity()
    {
        if (previewObject == null)
            return false;

        // 프리뷰의 Renderer bounds로 충돌 체크
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
    // 6) 설치 확정
    // ────────────────────────────────────────────────
    public void TryPlaceStructure()
    {
        if (!CheckPlacementValidity())
        {
            Debug.Log("설치 불가!");
            return;
        }

        Instantiate(
            currentBuildData.constructionPrefab,
            previewObject.transform.position,
            previewObject.transform.rotation);

        ExitBuildMode();
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



