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

    private void Update()
    {
        if (!buildMode.IsBuildingMode) return;
        if (buildCatalog == null || buildCatalog.buildList.Count == 0) return;

        // 1번 키 -> 첫 번째 BuildData
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SelectByIndex(0);
        }

        // 2번 키 -> 두 번째 BuildData
        if (Keyboard.current.digit2Key.wasPressedThisFrame && buildCatalog.buildList.Count > 1)
        {
            SelectByIndex(1);
        }

        // 필요하면 3,4,... 도 추가
    }

    void SelectByIndex(int index)
    {
        var data = buildCatalog.buildList[index];
        Debug.Log($"[Build] Select BuildData: {data.displayName}");

        buildMode.SelectBuildData(data);
    }
}




