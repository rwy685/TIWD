using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float defaultSpeed = 5;
    public float runSpeed = 10;
    public float staminaCostRun = 1;
    private Vector2 curMovementInput;

    public float jumpPower;
    public LayerMask groundLayerMask;

    public Action inventory;

    private PlayerState playerState;
    private Rigidbody rigidbody;
    private PlayerCondition condition;

    [HideInInspector] public bool canLook = true;
    public Equipment equipment; // Player가 가지고 있는 Equipment 컴포넌트

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        condition = GetComponent<PlayerCondition>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SetState(PlayerState.Idle);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void SetState(PlayerState state)
    {
        playerState = state;

        switch (playerState)
        {
            case PlayerState.Idle:
            case PlayerState.Walk:
                moveSpeed = defaultSpeed;
                break;

            case PlayerState.Run:
                moveSpeed = runSpeed;
                break;

            case PlayerState.Attack:
                break;
        }
    }

    // ============================================================
    //  InputSystemManager 에서 받은 입력값을 직접 전달하는 구조
    // ============================================================

    // 이동 입력값만 받는다 (값만 전달)
    public void SetMoveInput(Vector2 input)
    {
        curMovementInput = input;
    }

    // 걷기 → 뛰기 상태 전환
    public void StartRun()
    {
        SetState(PlayerState.Run);
    }

    public void StopRun()
    {
        SetState(PlayerState.Walk);
    }

    public void TryJump()
    {
        if (IsGrounded())
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    public void ToggleInventory()
    {
        inventory?.Invoke();
        ToggleCursor();
    }

    public void TryAttack()
    {
        if (equipment != null)
            equipment.OnAttackInput();
    }
    // ============================================================

    private void Move()
    {
        // 달리기 상태에서 스태미너를 소모
        if (playerState == PlayerState.Run && curMovementInput.magnitude > 0)
        {
            if (condition.UseStamina(staminaCostRun * Time.fixedDeltaTime))
            {
                // 스태미너 고갈 → 걷기로 전환
                SetState(PlayerState.Walk);
            }
        }

        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;

        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;

        rigidbody.velocity = dir;
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}
