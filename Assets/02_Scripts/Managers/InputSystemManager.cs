using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemManager : MonoBehaviour
{
    public enum InputMode { Basic, BuildMode } // Basic 기본 // BuildMode 건축모드
    public InputMode CurrentMode = InputMode.Basic;

    private PlayerController player;
    private PlayerCamera playerCamera;
    private BuildModeController buildMode;
    private Interaction interaction;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        playerCamera = GetComponent<PlayerCamera>();
        buildMode = GetComponent<BuildModeController>();
        interaction = GetComponent<Interaction>();
    }

    // =====================================================
    // 모드 전환 (B 키)
    // =====================================================
    public void OnBuildModeToggle(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;

        if (CurrentMode == InputMode.Basic)
        {
            CurrentMode = InputMode.BuildMode;
            Debug.Log("건축모드 진입");
            buildMode.EnterBuildMode();
        }
        else
        {
            Debug.Log("건축모드 나가기");
            buildMode.ExitBuildMode();
            CurrentMode = InputMode.Basic;
        }
    }

    // =====================================================
    // 항상 가능한 입력 (이동)
    // =====================================================
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 move = ctx.ReadValue<Vector2>();
        player.SetMoveInput(move);
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        playerCamera.SetLookInput(ctx.ReadValue<Vector2>());   // PlayerCamera에서 처리
    }


    // =====================================================
    // Basic 모드 전용 입력
    // =====================================================
    public void OnRun(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.Basic)
        {
            if (ctx.started) player.StartRun();
            if (ctx.canceled) player.StopRun();
        }
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.Basic && ctx.started)
            player.TryJump();
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.Basic && ctx.started)
            player.TryAttack();
    }

    public void OnInventory(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.Basic && ctx.started)
            player.ToggleInventory();
    }

    // Interaction 입력 차단
    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.Basic)
        {
            if (ctx.started && interaction != null)
                interaction.OnInteractInput(ctx);
        }
    }

    // =====================================================
    // BuildMode 전용 입력
    // =====================================================
    public void OnBuildPlace(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.BuildMode)
            buildMode.OnBuildPlace(ctx);
    }

    public void OnBuildRotateLeft(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.BuildMode)
            buildMode.OnBuildRotateLeft(ctx);
    }

    public void OnBuildRotateRight(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.BuildMode)
            buildMode.OnBuildRotateRight(ctx);
    }

    public void OnBuildDismantle(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.BuildMode)
            buildMode.OnBuildDismantle(ctx);
    }

    public void OnBuildCatalogOpen(InputAction.CallbackContext ctx)
    {
        if (CurrentMode == InputMode.BuildMode)
            buildMode.OnToggleCatalog(ctx);
    }

}


