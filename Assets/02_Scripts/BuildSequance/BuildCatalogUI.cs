using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildCatalogUI : MonoBehaviour
{
    [Header("Catalog Settings")]
    public BuildCatalog catalog;         // SO 연결
    public GameObject catalogWindow;     // Panel
    public Transform buttonContainer;    // 버튼컨테이너
    public GameObject buttonPrefab;      // 각 BuildData 항목 UI

    [Header("Shortage Text")]
    public TMP_Text shortageText; // 자원 부족한지 나타내주는 텍스트
    private Coroutine shortageRoutine;

    private BuildModeManager buildMode;

    private void Start()
    {
        buildMode = GameManager.Instance.buildModeManager;
        GenerateButtons();
        Close();

        if (shortageText != null)
            shortageText.gameObject.SetActive(false);
    }

    private void GenerateButtons()
    {
        foreach (var data in catalog.buildList)
        {
            GameObject btnObj = Instantiate(buttonPrefab, buttonContainer);

            var btn = btnObj.GetComponent<BuildCatalogButton>();
            btn.Initialize(data, this); // BuildData 전달
        }
    }

    // ==========================================
    // 카탈로그 열기 / 닫기
    // ==========================================

    public void Open()
    {
        catalogWindow.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Close()
    {
        catalogWindow.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // ==========================================
    // 버튼 클릭 처리
    // ==========================================

    public void OnClickSelectBuild(BuildData data)
    {
        var inv = GameManager.Instance.characterManager.player.inventory;

        // 재료 부족 체크
        if (!buildMode.ResourceHandler.CheckResourceShortage(data, inv, out var shortfall))
        {
            ShowShortage(shortfall);
            return;  // 자원 부족시 카탈로그 안닫히게
        }

        // 재료 충분 시 건축 선택
        buildMode.OnCatalogSelected(data);

        // 카탈로그 닫기
        buildMode.ToggleCatalog();
    }

    // ==========================================
    // 자원 부족시 텍스트 출력
    // ==========================================

    public void ShowShortage(Dictionary<ItemData, int> shortfall)
    {
        if (shortageText == null)
            return;

        string msg = "재료가 부족합니다:\n";

        foreach (var kvp in shortfall)
            msg += $"{kvp.Key.displayName} x {kvp.Value}\n";

        if (shortageRoutine != null)
            StopCoroutine(shortageRoutine);

        shortageRoutine = StartCoroutine(ShowShortageRoutine(msg));
    }
    
    // 2초 지연
    private IEnumerator ShowShortageRoutine(string msg)
    {
        shortageText.text = msg;
        shortageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        shortageText.gameObject.SetActive(false);
        shortageRoutine = null;
    }
}

