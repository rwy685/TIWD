using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCamera playerCamera;

    public void Init()
    {
        controller = GetComponent<PlayerController>();
        playerCamera = GetComponent<PlayerCamera>();
        //GameManager.Instance.characterManager.player = this;

        GetComponent<PlayerCondition>().Init();
    }

    private void Awake()
    {
        Init();
    }
}