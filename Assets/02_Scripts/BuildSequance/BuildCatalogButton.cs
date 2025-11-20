using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildCatalogButton : MonoBehaviour
{
    [HideInInspector] public BuildData data;
    private BuildCatalogUI catalogUI;

    public Image iconImage;
    public TMP_Text nameText; // 선택 사항

    public void Initialize(BuildData data, BuildCatalogUI ui)
    {
        this.data = data;
        this.catalogUI = ui;

        // BuildData.icon 사용
        if (iconImage != null)
            iconImage.sprite = data.icon;

        if (nameText != null)
            nameText.text = data.displayName;
    }

    // Button.onClick → 이 함수 연결
    public void OnClick()
    {
        catalogUI.OnClickSelectBuild(data);
    }
}
