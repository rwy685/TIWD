using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeUI : MonoBehaviour
{
    public GameObject buildModePanel;

    public void ShowBuildModePanel()
    {
        if (buildModePanel != null)
            buildModePanel.SetActive(true);

        // 빌드모드에서는 커서 잠금 유지
       
    }

    public void HideBuildModePanel()
    {
        if (buildModePanel != null)
            buildModePanel.SetActive(false);

        // Basic 모드로 돌아갈 때 InputSystemManager가 원래대로 함
    }
}

