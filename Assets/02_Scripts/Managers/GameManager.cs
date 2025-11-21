using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public SpawnManager spawnManager;
    public CharacterManager characterManager;
    public CraftManager craftManager;
    public BuildModeManager buildModeManager; // 건축모드매니저 추가
    public InventoryUI inventoryUI;
    public DayNightCycle dayNightCycle;

    public float curTime = 0f;
    public float nightTime;
    public float endTime;
    public int day = 1;
    public bool isNight;

    private void Start()
    {
        characterManager.Init();
        inventoryUI.Init();
        spawnManager.ItemSpawn();
    }
    
    private void Update()
    {
        curTime = dayNightCycle.time * 24f;

        bool nowNight = (curTime >= nightTime || curTime < endTime);

        if (nowNight && !isNight)
        {
            isNight = true;
            spawnManager.EnemySpawn();
            AudioManager.Instance.PlayBGM(AudioManager.BGMType.Night);
        }
        else if (!nowNight && isNight)
        {
            isNight = false;
            day++;
            AudioManager.Instance.PlayBGM(AudioManager.BGMType.Day);
        }
    }
}
