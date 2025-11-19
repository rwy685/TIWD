using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameManager.Instance.characterManager.player;
    }

    public void Equip(ItemData data)
    {
    }

    public void UnEquip()
    {
    }
}