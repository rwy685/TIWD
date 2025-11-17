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
    Stone
}

[CreateAssetMenu(fileName = "BuildResourceData", menuName = "New BuildResourceData")]
public class BuildResourceData : ScriptableObject
{
    [Header("Info")]
    public ResourceType resourceType;
    public int amount;
}
