using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingPanel : MonoBehaviour
{
    [Header("Recipe List UI")]
    public Transform recipeButtonList;       // RecipeButton 들이 들어있는 부모(스크롤뷰)
    public Button[] recipeButtons;           // 각 버튼
                                             // (Start에서 자동으로 가져올 예정)

    [Header("Recipe Info UI")]
    public TextMeshProUGUI recipeNameText;   // 선택된 레시피 이름 표시
    public TextMeshProUGUI[] ingredientTexts; // IngredientText1~3
    public Button makeButton;                // "만들기" 버튼

    private CraftManager craftManager => GameManager.Instance.craftManager;
    private List<CraftData> craftRecipes => craftManager.GetAllRecipes();
    private CraftData selectedRecipe = null;

    void Start()
    {
        // 버튼들 자동 인식
        recipeButtons = recipeButtonList.GetComponentsInChildren<Button>();

        // CraftData 리스트 개수와 버튼 수가 동일하다는 가정 하에 설정
        for (int i = 0; i < recipeButtons.Length; i++)
        {
            int index = i; // 람다 캡처 문제 방지
            recipeButtons[i].onClick.AddListener(() =>
            {
                OnRecipeButtonClicked(index);
            });

            // 버튼에 레시피 이름 표시
            TextMeshProUGUI txt = recipeButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            txt.text = craftRecipes[index].resultItem.displayName;
        }

        // 만들기 버튼 이벤트 설정
        makeButton.onClick.AddListener(OnMakeButtonClicked);

        // 시작할 땐 Info 비워두기
        ClearRecipeInfo();
    }

    // ==============================
    //      버튼 클릭 시 레시피 선택
    // ==============================
    void OnRecipeButtonClicked(int index)
    {
        selectedRecipe = craftRecipes[index];
        UpdateRecipeInfo(selectedRecipe);
    }

    // ==============================
    //         Info 업데이트
    // ==============================
    void UpdateRecipeInfo(CraftData recipe)
    {
        recipeNameText.text = recipe.resultItem.displayName;

        // 재료 텍스트 초기화
        for (int i = 0; i < ingredientTexts.Length; i++)
            ingredientTexts[i].text = "";

        // 재료 표시 (최대 3개 가정)
        for (int i = 0; i < recipe.ingredients.Length && i < ingredientTexts.Length; i++)
        {
            string name = recipe.ingredients[i].item.displayName;
            int amount = recipe.ingredients[i].amount;

            ingredientTexts[i].text = $"{name} x {amount}";
        }

        makeButton.interactable = true;
    }

    // ==============================
    //     만들기 버튼 눌렀을 때
    // ==============================
    void OnMakeButtonClicked()
    {
        if (selectedRecipe == null)
            return;

        // 제작 시도
        bool success = craftManager.DoCraft(selectedRecipe);

        if (success)
        {
            Debug.Log($"제작 성공: {selectedRecipe.resultItem.displayName}");
            // 다시 Info 업데이트 (재료 부족 표시 등을 반영)
            UpdateRecipeInfo(selectedRecipe);
        }
        else
        {
            Debug.Log("재료 부족으로 제작 실패");
        }
    }

    // ==============================
    //     Info 초기화
    // ==============================
    void ClearRecipeInfo()
    {
        recipeNameText.text = "레시피를 선택하세요";

        foreach (var t in ingredientTexts)
            t.text = "";

        makeButton.interactable = false;
    }
}
