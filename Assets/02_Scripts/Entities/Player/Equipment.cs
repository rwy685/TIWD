using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    private Player player;

    void Start()
    {
        player = GameManager.Instance.characterManager.player;
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
       // curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();
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
}