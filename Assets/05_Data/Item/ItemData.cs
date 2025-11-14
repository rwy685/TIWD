using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,      // 장착 아이템
    Consumable,     // 소비 아이템
    Resource        // 기타 자원
}

[CreateAssetMenu(fileName = "NewItem", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string displayDesc;
    public ItemType type;
}
