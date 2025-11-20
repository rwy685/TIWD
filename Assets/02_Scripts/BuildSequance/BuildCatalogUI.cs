using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCatalogUI : MonoBehaviour
{
    public BuildCatalog catalog;         // SO 연결
    public GameObject catalogWindow;     // Panel
    public Transform buttonContainer;    // 버튼컨테이너
    public GameObject buttonPrefab;      // 각 BuildData 항목 UI

    private BuildModeManager buildMode;

    private void Start()
    {
        buildMode = GameManager.Instance.buildModeManager;
        GenerateButtons();
        Close();
    }

    private void GenerateButtons()
    {
        foreach (var data in catalog.buildList)
        {
            GameObject btnObj = Instantiate(buttonPrefab, buttonContainer);
            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(() => OnClickSelectBuild(data));

            //  UI 표시(아이콘/텍스트)
            var text = btnObj.GetComponentInChildren<TMPro.TMP_Text>();
            if (text != null)
                text.text = data.displayName;

            var img = btnObj.GetComponentInChildren<Image>();
            if (img != null)
                img.sprite = data.icon;
        }
    }

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

    public void OnClickSelectBuild(BuildData data)
    {
        buildMode.OnCatalogSelected(data);
        Close();
    }
}

