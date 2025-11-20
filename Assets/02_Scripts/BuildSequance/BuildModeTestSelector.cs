using UnityEngine;
using UnityEngine.InputSystem;

public class BuildModeTestSelector : MonoBehaviour
{
    public BuildCatalog buildCatalog; // 인스펙터에 SO 연결

    private BuildModeManager buildMode;

    private void Start()
    {
        buildMode = GameManager.Instance.buildModeManager;
    }

    void Update()
    {
        if (!buildMode.IsBuildingMode) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            SelectByIndex(0);

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            SelectByIndex(1);

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            SelectByIndex(2);

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
            SelectByIndex(3);
    }

    void SelectByIndex(int index)
    {
        var data = buildCatalog.buildList[index];
        Debug.Log($"[Build] Select BuildData: {data.displayName}");

        buildMode.SelectBuildData(data);
    }
}




