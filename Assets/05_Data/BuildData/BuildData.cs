using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BuildType
{
    CampFire,
    Tent, 
    Fence,
    Rock
}

[System.Serializable]
public class BuildRequirement
{
    public ItemData item; // 필요한 자원 타입(인벤토리)
    public int amount; // 필요한 갯수

    //ItemType 리소스만 사용할 수 있도록
    public bool IsValid()
    {
        return item != null && item.itemType == ItemType.Resource;
    }
}

[CreateAssetMenu(fileName = "BuildData", menuName = "New BuildData")]
public class BuildData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string displayDesc;
    public BuildType buildType;
    public Image icon;

    [Header("NeedResource")]
    public List<BuildRequirement> requirements; // 자원 종류타입 여러개 필요

    [Header("PreviewPrefab")]
    public GameObject previewPrefab;

    [Header("CompletePrefab")]
    public GameObject completePrefab;

    //건축 자원 체크용(ItemType : Resource 만)
    private void OnValidate()
    {
        foreach (var req in requirements)
        {
            if (req.item != null && req.item.itemType != ItemType.Resource)
            {
                Debug.LogWarning($"[BuildData] {req.item.name} 은 Resource 타입이 아님.");
                req.item = null; // 자동 초기화
            }
        }
    }
}

