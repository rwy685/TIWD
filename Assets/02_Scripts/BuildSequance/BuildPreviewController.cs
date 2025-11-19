using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPreviewController
{
    private GameObject previewObject;
    private Renderer[] previewRenderers;

    private Material previewValidMat;
    private Material previewInvalidMat;

    private Camera cam;

    //외부에서 전달받는 값들
    private LayerMask groundMask;
    private LayerMask obstructionMask;
    private float rotateSpeed;

    //BuildModeManager에서 설정값을 전달받도록 변경
    public BuildPreviewController(LayerMask groundMask, LayerMask obstructionMask, float rotateSpeed)
    {
        cam = Camera.main;

        this.groundMask = groundMask;
        this.obstructionMask = obstructionMask;
        this.rotateSpeed = rotateSpeed;
    }

    // 
    // 3) Preview 생성
    // 
    public void CreatePreviewObject(BuildData data)
    {
        previewObject = Object.Instantiate(data.previewPrefab);
        previewRenderers = previewObject.GetComponentsInChildren<Renderer>();

        previewValidMat = Resources.Load<Material>("TestMaterial/PreviewValid");
        previewInvalidMat = Resources.Load<Material>("TestMaterial/PreviewInvalid");

        foreach (var rend in previewRenderers)
            rend.material = previewValidMat;
    }

    public void DestroyPreview()
    {
        if (previewObject != null)
            Object.Destroy(previewObject);

        previewObject = null;
    }

    //
    // 프리뷰 들고 있는 상태에서 이동시 위치 업데이트
    //
    public void UpdatePreviewPosition()
    {
        if (previewObject == null) return;

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        
        if (Physics.Raycast(ray, out RaycastHit hit, 30f, groundMask))
        {
            previewObject.transform.position = hit.point;

            bool valid = CheckPlacementValidity();
            UpdatePreviewMaterial(valid);
        }
    }

    // 
    // 4) 설치 가능 여부 검사
    //
    public bool CheckPlacementValidity()
    {
        Bounds bounds = GetPreviewBounds();

        //
        Collider[] hits = Physics.OverlapBox(
            bounds.center,
            bounds.extents,
            previewObject.transform.rotation,
            obstructionMask
        );

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

    public bool HasPreview() => previewObject != null;

    //
    // 7) 회전 기능
    //
    public void Rotate(int direction)
    {
        if (previewObject == null) return;

        
        previewObject.transform.Rotate(Vector3.up, direction * rotateSpeed);
    }

    public Vector3 GetPosition() => previewObject.transform.position;
    public Quaternion GetRotation() => previewObject.transform.rotation;
}


