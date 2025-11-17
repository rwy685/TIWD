using System;
using UnityEngine;

[Serializable]
public class RecoveryData
{
    public ConsumableType consumableType;
    public int recoveryAmount;
}

[CreateAssetMenu(fileName = "NewItem", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string displayDesc;
    public ItemType itemType;
    public Sprite inventoryIcon;
    public GameObject itemPrefab;

    [Header("Equipable")]
    public EquipableType equipableType;
    public int attackPower;     // 무기용
    public int gatherPower;     // 도구용

    [Header("Consumable")]
    public RecoveryData[] recoveryData;

    [Header("StackingInfo")]
    public bool isStackable;
    public int maxStack = 99;
}
