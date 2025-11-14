using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCamera playerCamera;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        playerCamera = GetComponent<PlayerCamera>();
    }
}