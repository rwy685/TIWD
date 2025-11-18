using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildModeController : MonoBehaviour
{
    private BuildModeManager buildMode;
    public BuildData testBuildData; // Inspector에서 테스트용 SO 넣어두기

    private void Start()
    {
        buildMode = GameManager.Instance.buildModeManager;
    }

    private void Update()
    {
        if (buildMode == null) return;  // 안전장치

        if (Keyboard.current.digit1Key?.wasPressedThisFrame == true)
        {
            if (testBuildData != null)
                buildMode.EnterBuildMode(testBuildData);
            else
                Debug.LogWarning("testBuildData가 설정되지 않았습니다!");
        }
    }


    // 
    // 빌드 모드 전용 컨트롤러
    // 

    // 마우스 좌클릭: 해당 위치 설치
    public void OnBuildPlace(InputAction.CallbackContext ctx)
    {
        if (!buildMode.IsBuildingMode) return;
        if (ctx.phase == InputActionPhase.Started)
            buildMode.TryPlaceStructure();
    }

    // Q: 사전구조물 설치방향 왼쪽으로 돌리기(반시계방향)
    public void OnBuildRotateLeft(InputAction.CallbackContext ctx)
    {
        if (!buildMode.IsBuildingMode) return;
        if (ctx.phase == InputActionPhase.Started)
            buildMode.RotateLeft();
    }

    // E: 사전구조물 설치방향 오른쪽으로 돌리기(시계방향)
    public void OnBuildRotateRight(InputAction.CallbackContext ctx)
    {
        if (!buildMode.IsBuildingMode) return;
        if (ctx.phase == InputActionPhase.Started)
            buildMode.RotateRight();
    }

    // ESC: 설치 취소
    public void OnBuildCancel(InputAction.CallbackContext ctx)
    {
        if (!buildMode.IsBuildingMode) return;
        if (ctx.phase == InputActionPhase.Started)
            buildMode.ExitBuildMode();
    }
}

