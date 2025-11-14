using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private float spawnTime;
    [SerializeField] private int spawnCount;
    [SerializeField] private int spawnDelay;

    private int curCount = 0;
    private WaitForSeconds wait;

    public void Init()
    {
        Spawn();
        wait = new WaitForSeconds(spawnDelay);
    }

    private void Spawn()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (curCount < spawnCount)
        {
            foreach (var spawn in spawnPoint)
            {
                int randIndex = Random.Range(0, enemyPrefab.Length);

                Instantiate(enemyPrefab[randIndex], spawn.position, Quaternion.identity);
                curCount++;
            }
            yield return wait;
        }
    }
}
