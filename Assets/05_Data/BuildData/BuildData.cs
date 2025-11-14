using UnityEngine;


public enum BuildType
{
    CampFire,
    Tent, 
    Fence,
    Rock
}

[CreateAssetMenu(fileName = "BuildData", menuName = "New BuildData")]
public class BuildData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string displayDesc;
    public BuildType buildType;

    [Header("NeedResource")]
    public int neededResource;

    [Header("BuildComplete")]
    public GameObject CompletePrefab;
}

