using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerSpawner playerSpawner;
    public EnemySpawner enemySpawner;

    public ItemSpawner itemSpawner;

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

        if (itemSpawner == null)
        {
            itemSpawner = GetComponentInChildren<ItemSpawner>();
        }

        playerSpawner.Init();
        itemSpawner.Init();
    }

    public void EnemySpawn()
    {
        enemySpawner.Init();
    }
}
