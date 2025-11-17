using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCamera playerCamera;

    // 인벤토리 관련 변수
    public BuildResourceData acquiredItem;    // Player 가 현재 획득한 아이템
    public Action addItem;           // 아이템 획득시 실행할 델리게이트

    // 컨디션 관련 변수
    public PlayerCondition condition;


    private void Awake()
    {

        controller = GetComponent<PlayerController>();
        playerCamera = GetComponent<PlayerCamera>();
        condition = GetComponent<PlayerCondition>();
        //GameManager.Instance.characterManager.player = this;
    }

    // Awake 에서 대입 시, CharacterManager 가 아직 초기화되지 않아 연결 안 됨
    private void Start()
    {
        GameManager.Instance.characterManager.player = this;
    }
}