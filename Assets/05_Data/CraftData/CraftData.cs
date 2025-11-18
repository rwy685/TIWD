using System;
using UnityEngine;

[Serializable]
public class CraftingIngredient
{
    public ItemData item;
    public int amount;
}

[CreateAssetMenu(fileName = "Craft_", menuName = "New CraftData")]
public class CraftData : ScriptableObject
{
    [Header("Crafting Ingredients")]
    public CraftingIngredient[] ingredients;

    [Header("Crafting Result")]
    public ItemData resultItem;
    public int resultAmount = 1;
}
