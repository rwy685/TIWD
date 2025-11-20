using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingPanel : MonoBehaviour
{
    [Header("Recipe List UI")]
    public Transform recipeButtonList;
    public Button[] recipeButtons;

    [Header("Recipe Button Labels (TMP Text)")]
    public TMP_Text[] recipeButtonLabels;

    [Header("Recipe Info UI")]
    public TMP_Text recipeNameText;
    public TMP_Text[] ingredientTexts;

    [Header("Make Button")]
    public Button makeButton;

    // 내부 데이터
    // 내부 데이터
    private CraftData[] craftRecipes;
    private CraftData selectedRecipe;

    void Start()
    {
        // 1) GameManager → CraftManager → 레시피 받아오기
        craftRecipes = GameManager.Instance.craftManager.GetAllRecipes().ToArray();

        // 2) UI 버튼 초기화
        InitButtons();

        // 3) 기본적으로 표시 비우기
        //ClearRecipeInfo();
    }


    // =====================================
    // 버튼 초기화
    // =====================================
    private void InitButtons()
    {
        for (int i = 0; i < recipeButtons.Length; i++)
        {
            int index = i;

            // 버튼 클릭 이벤트 초기화 후 다시 세팅
            recipeButtons[i].onClick.RemoveAllListeners();
            recipeButtons[i].onClick.AddListener(() => OnRecipeButtonClicked(index));


            // 버튼 라벨 넣기
           
                recipeButtonLabels[i].text = craftRecipes[i].resultItem.displayName;
                Debug.Log($"[InitButton] index={i}, name={craftRecipes[i].resultItem.displayName}");
        }
    }


    // =====================================
    // 버튼 클릭 시 레시피 선택
    // =====================================
    private void OnRecipeButtonClicked(int index)
    {
        if (index < 0 || index >= craftRecipes.Length)
            return;

        selectedRecipe = craftRecipes[index];
        Debug.Log($"[Select] index={index}, name={selectedRecipe.resultItem.displayName}");

        UpdateRecipeInfo(selectedRecipe);
    }


    // =====================================
    // 선택된 레시피 UI 갱신
    // =====================================
    private void UpdateRecipeInfo(CraftData recipe)
    {
        //recipeNameText.text = recipe.resultItem.displayName;

        // 재료 표시
        for (int i = 0; i < ingredientTexts.Length; i++)
        {
            if (i < recipe.ingredients.Length)
            {
                var ing = recipe.ingredients[i];
                ingredientTexts[i].text = $"{ing.item.displayName} x {ing.amount}";
            }
            else
            {
                ingredientTexts[i].text = "";
            }
        }
    }


    // =====================================
    // Craft 버튼 누르면 실행
    // =====================================
    public void OnMakeButtonClicked()
    {
        if (selectedRecipe == null) return;

        GameManager.Instance.craftManager.DoCraft(selectedRecipe);
        Debug.Log($"[CRAFT] {selectedRecipe.resultItem.displayName} 제작 시도");

        ClearRecipeInfo();
    }


    // =====================================
    // 선택해제 / 클리어
    // =====================================
    private void ClearRecipeInfo()
    {
        //recipeNameText.text = "";

        foreach (var txt in ingredientTexts)
            txt.text = "";

        selectedRecipe = null;
    }
}
