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

    //
    // 빌드모드 진입 입력 (B키로 예정)
    //
    public void OnBuildModeToggle(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;

        if (!buildMode.IsBuildingMode)
        {
            Debug.Log("Build Mode Enter");
            buildMode.EnterBuildMode();      // 빌드모드 진입
        }
        else
        {
            Debug.Log("Build Mode Exit");
            buildMode.ExitBuildMode(); // 빌드모드 종료
        }
    }


    // 
    // 빌드 모드 전용 컨트롤러
    // 

    // 마우스 좌클릭: 해당 위치 설치
    public void OnBuildPlace(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;
        if (!buildMode.IsBuildingMode) return;

        buildMode.TryPlaceStructure();
    }

    // Q: 사전구조물 설치방향 왼쪽으로 돌리기(반시계방향)
    public void OnBuildRotateLeft(InputAction.CallbackContext ctx)
    {
        if (ctx.started && buildMode.IsBuildingMode)
            buildMode.RotateLeft();
    }


    // E: 사전구조물 설치방향 오른쪽으로 돌리기(시계방향)
    public void OnBuildRotateRight(InputAction.CallbackContext ctx)
    {
        if (ctx.started && buildMode.IsBuildingMode)
            buildMode.RotateRight();
    }

    // ESC: 설치 취소
    public void OnBuildCancel(InputAction.CallbackContext ctx)
    {
        if (ctx.started && buildMode.IsBuildingMode)
            buildMode.ExitBuildMode();
    }
}

