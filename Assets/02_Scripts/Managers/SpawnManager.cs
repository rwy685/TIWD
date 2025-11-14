using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerSpawner playerSpawner;
    public EnemySpawner enemySpawner;

    public void Init()
    {
        if (playerSpawner == null)
        {
            playerSpawner = GetComponentInChildren<PlayerSpawner>();
        }

        if (enemySpawner == null)
        {
            enemySpawner = GetComponentInChildren<EnemySpawner>();
        }

        playerSpawner.Init();
    }

    public void EnemySpawn()
    {
        enemySpawner.Init();
    }
}
