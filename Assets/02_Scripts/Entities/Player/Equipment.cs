using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public EquipItem curEquip;
    public Transform equipParent;
    private PlayerController controller;

    void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<EquipItem>();
        Debug.Log("장착");
    }

    public void UnEquip()
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curEquip != null && controller.canLook)
        {
            curEquip.OnUse();
        }
    }
}