using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CraftManager : MonoBehaviour
{
    [SerializeField] private List<CraftData> craftRecipes;

    private Inventory inventory;

    private IEnumerator Start()
    {
        // Player가 생성될 때까지 대기
        while (GameManager.Instance == null ||
               GameManager.Instance.characterManager == null ||
               GameManager.Instance.characterManager.player == null ||
               GameManager.Instance.characterManager.player.inventory == null)
        {
            yield return null;
        }

        // Player 준비 완료 후 인벤토리 연결
        inventory = GameManager.Instance.characterManager.player.inventory;
    }

    public List<CraftData> GetAllRecipes() => craftRecipes;

    // 인벤토리에 해당 제작 레시피에 필요한 재료가 충분한지 확인
    public bool CanCraft(CraftData recipe)
    {
        foreach (var ingredient in recipe.ingredients)
        {
            // 인벤토리에 해당 아이템을 'ingredient.amount 만큼' 가지고 있는지 체크
            if (!inventory.Has(ingredient.item, ingredient.amount))
                return false;
        }

        return true;
    }

    public bool DoCraft(CraftData recipe)
    {
        // 1) 제작 가능한지 확인
        if (!CanCraft(recipe))
        {
            Debug.Log("[DoCraft] 재료가 부족하여 제작 불가");
            return false;
        }
        // 2) 재료 소모
        foreach (var ingredient in recipe.ingredients)
        {
            inventory.ConsumeMultiple(ingredient.item, ingredient.amount);
        }
        // 3) 결과 아이템 인벤토리에 추가
        inventory.AddItemToInventory(recipe.resultItem, recipe.resultAmount);
        Debug.Log("[DoCraft] 제작 완료: " + recipe.resultItem.displayName);
        return true;
    }
}
