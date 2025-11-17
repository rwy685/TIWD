using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*/테스트용 건축자원용 SO생성 스크립트
 * 추후 변경
 * 
 * 
/*/
public enum ResourceType
{
    Wood,
    Stone,
    Flint
}

[CreateAssetMenu(fileName = "BuildResourceData", menuName = "New BuildResourceData")]
public class BuildResourceData : ScriptableObject
{
    [Header("Meta Info")]
    public string displayName;

    [Header("Inventory Item 연결")]
    public ItemData itemData;

    [Header("Info")]
    public ResourceType resourceType;
}
