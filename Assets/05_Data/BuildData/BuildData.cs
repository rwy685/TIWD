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
    public BuildResourceData resource; // 필요한 자원 타입(인벤토리)
    public int amount; // 필요한 갯수
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

    [Header("BuildComplete")]
    public GameObject completePrefab;
}

