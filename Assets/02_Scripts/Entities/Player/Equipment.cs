using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;
    private Player player;
    private PlayerController controller;

    void Start()
    {
        player = GameManager.Instance.characterManager.player;
        controller = player.controller;
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();
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

    public void OnUseEquipItem(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curEquip != null && controller.canLook)
        {
            curEquip.OnUse();
        }
    }
}