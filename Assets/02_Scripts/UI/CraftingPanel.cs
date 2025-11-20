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

    //public TMP_Text recipeNameText;

    [Header("Ingredient Icons")]
    public Image[] ingredientIcons;
    public TMP_Text[] ingredientTexts;

    [Header("Make Button")]
    public Button makeButton;

    // 내부 데이터
    // 내부 데이터
    private CraftData[] craftRecipes;
    private CraftData selectedRecipe;

    public Image resultItemIcon;
    public TMP_Text resultItemNameText;

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
    public void OnRecipeButtonClicked(int index)
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
        int count = recipe.ingredients.Length;

        for (int i = 0; i < ingredientIcons.Length; i++)
        {
            if (i < count)
            {
                var ing = recipe.ingredients[i];

                // 아이콘
                ingredientIcons[i].sprite = ing.item.inventoryIcon;
                ingredientIcons[i].color = Color.white;

                // 텍스트 (재료 이름 + 수량)
                ingredientTexts[i].text = $"{ing.item.displayName} x {ing.amount}";

                // 슬롯 활성화
                ingredientIcons[i].transform.parent.gameObject.SetActive(true);
            }
            else
            {
                // 남는 슬롯 숨김
                ingredientIcons[i].sprite = null;
                ingredientIcons[i].color = new Color(1, 1, 1, 0);
                ingredientTexts[i].text = "";

                ingredientIcons[i].transform.parent.gameObject.SetActive(false);
            }

            resultItemIcon.sprite = recipe.resultItem.inventoryIcon;
        }
    }


    // =====================================
    // Craft 버튼 누르면 실행
    // =====================================
    public void OnMakeButtonClicked()
    {
        Debug.Log("=== CRAFT 테스트 ===");
        Debug.Log("선택된 레시피 결과 아이템: " + selectedRecipe.resultItem.displayName);
        Debug.Log("재료 충족 여부: " + GameManager.Instance.craftManager.CanCraft(selectedRecipe));


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
