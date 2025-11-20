using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildModeController : MonoBehaviour
{
    private BuildModeManager buildMode;

    private void Awake()
    {
        buildMode = GameManager.Instance.buildModeManager;
    }

    public void EnterBuildMode() 
    {
        buildMode.EnterBuildMode();
    }

    public void ExitBuildMode()
    {
        buildMode.ExitBuildMode();
    }

    public void OnBuildPlace(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            buildMode.TryPlaceStructure();
    }

    public void OnBuildRotateLeft(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            buildMode.RotateLeft();
    }

    public void OnBuildRotateRight(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            buildMode.RotateRight();
    }

    public void OnBuildCancel(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            buildMode.ExitBuildMode();
    }
}


