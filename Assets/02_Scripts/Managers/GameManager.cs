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
    public BuildManager buildManager; // 빌드매니저 추가함
    public BuildModeManager buildModeManager; // 건축모드매니저 추가

    public float curTime = 0f;
    public float nightTime;
    public float endTime;
    public bool isNight;

    private void Start()
    {
        spawnManager.Init();
    }

    private void Update()
    {
        curTime += Time.deltaTime;

        if (curTime > endTime && isNight)
        {
            isNight = false;
            curTime = 0f;
        }
        else if (curTime > nightTime && !isNight)
        {
            isNight = true;
            spawnManager.EnemySpawn();
        }
    }
}
