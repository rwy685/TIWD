using UnityEngine;
using UnityEngine.UI;

public class BuildCatalogPanel : MonoBehaviour
{
    public BuildCatalog catalog;    // SO
    public Transform iconParent;    // IconContainer
    public GameObject iconPrefab;   // Image Prefab

    void OnEnable()
    {
        RefreshIcons();
    }

    void RefreshIcons()
    {
        // 기존 아이콘 정리
        foreach (Transform child in iconParent)
            Destroy(child.gameObject);

        // BuildData 순서대로 아이콘 생성
        foreach (var data in catalog.buildList)
        {
            var obj = Instantiate(iconPrefab, iconParent);
            var img = obj.GetComponent<Image>();
            img.sprite = data.icon; // BuildData.icon(Sprite)
        }
    }
}



