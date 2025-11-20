using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlacementSystem
{
    private Camera cam;

    public BuildPlacementSystem(Camera camera)
    {
        this.cam = camera;
    }

    // 설치
    public void PlaceStructure(BuildData data, BuildPreviewController preview)
    {
        var obj = Object.Instantiate(
            data.completePrefab,
            preview.GetPosition(),
            preview.GetRotation()
        );

        // 설치된 객체에 BuildData 정보 부착
        var completeInfo = obj.AddComponent<BuildCompleteObject>();
        completeInfo.sourceData = data;
    }

    // 해체 
    public void DismantleStructure()
    {
        if (cam == null) return;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 5f))
        {
            var buildObj = hit.collider.GetComponentInParent<BuildCompleteObject>();
            if (buildObj == null)
                return;

            // 자원 환급
            var inv = GameManager.Instance.characterManager.player.inventory;
            foreach (var req in buildObj.sourceData.requirements)
            {
                inv.AddItemToInventory(req.item, req.amount);
            }

            // 오브젝트 파괴
            Object.Destroy(buildObj.gameObject);
            Debug.Log($"[Build] {buildObj.sourceData.displayName} 해체 완료");
        }
    }
}



