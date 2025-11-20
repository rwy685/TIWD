using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingPanel : MonoBehaviour
{
    [Header("Recipe List UI")]
    public Transform recipeButtonList;
    public Button[] recipeButtons;

    [Header("Recipe Info UI")]
    public TextMeshProUGUI recipeNameText;
    public TextMeshProUGUI[] ingredientTexts;
    public Button makeButton;

    private CraftManager craftManager => GameManager.Instance.craftManager;
    private List<CraftData> craftRecipes => craftManager.GetAllRecipes();
    private CraftData selectedRecipe = null;

    void Start()
    {
        recipeButtons = recipeButtonList.GetComponentsInChildren<Button>();

        for (int i = 0; i < recipeButtons.Length; i++)
        {
            int index = i;
            recipeButtons[i].onClick.AddListener(() => OnRecipeButtonClicked(index));

            TextMeshProUGUI txt = recipeButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            txt.text = craftRecipes[index].resultItem.displayName;
        }

        makeButton.onClick.AddListener(OnMakeButtonClicked);
        ClearRecipeInfo();
    }

    void OnRecipeButtonClicked(int index)
    {
        selectedRecipe = craftRecipes[index];
        UpdateRecipeInfo(selectedRecipe);
    }

    void UpdateRecipeInfo(CraftData recipe)
    {
        recipeNameText.text = recipe.resultItem.displayName;

        // 텍스트 초기화
        for (int i = 0; i < ingredientTexts.Length; i++)
        {
            ingredientTexts[i].text = "";
            ingredientTexts[i].color = Color.white;
        }

        // 플레이어 인벤토리
        var inventory = GameManager.Instance.characterManager.player.inventory;

        // 재료 표시 + 회색 처리
        for (int i = 0; i < recipe.ingredients.Length && i < ingredientTexts.Length; i++)
        {
            var ing = recipe.ingredients[i];
            int have = inventory.Count(ing.item);
            int need = ing.amount;

            ingredientTexts[i].text = $"{ing.item.displayName}  {have}/{need}";

            // 재료 부족하면 회색 처리
            if (have < need)
                ingredientTexts[i].color = Color.gray;
        }

        // 🔥 제작 가능 여부에 따라 버튼 활성화
        makeButton.interactable = craftManager.CanCraft(recipe);
    }

    void OnMakeButtonClicked()
    {
        if (selectedRecipe == null)
            return;

        bool success = craftManager.DoCraft(selectedRecipe);

        if (success)
        {
            Debug.Log($"제작 성공: {selectedRecipe.resultItem.displayName}");

            // 재료 소모 후 다시 UI 업데이트
            UpdateRecipeInfo(selectedRecipe);
            InventoryUI.Instance.RefreshAllSlots();
        }
        else
        {
            Debug.Log("재료 부족으로 제작 실패");
            UpdateRecipeInfo(selectedRecipe);
        }
    }

    void ClearRecipeInfo()
    {
        recipeNameText.text = "레시피를 선택하세요";

        foreach (var t in ingredientTexts)
        {
            t.text = "";
            t.color = Color.white;
        }

        makeButton.interactable = false;
    }
}
