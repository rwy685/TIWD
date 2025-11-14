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
