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

            var btn = btnObj.GetComponent<BuildCatalogButton>();
            btn.Initialize(data, this); // BuildData 전달
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

