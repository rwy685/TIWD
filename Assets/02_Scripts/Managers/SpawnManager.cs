using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    public ItemSpawner itemSpawner;

    public void ItemSpawn()
    {
        itemSpawner.Init();
    }

    public void EnemySpawn()
    {
        enemySpawner.Init();
    }
}
