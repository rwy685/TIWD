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

    // InputSystemManager -> PlayerController -> Equipment 로 들어와서 여기서 로직만 담당
    public void OnAttackInput()
    {
        if (curEquip != null && controller.canLook)
        {
            curEquip.OnUse();
        }
    }
}