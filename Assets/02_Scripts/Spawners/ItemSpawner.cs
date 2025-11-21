using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnHeight;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    [Header("보급 상자 세팅")]
    [SerializeField] private GameObject supplyCratePrefab;

    public void Init()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnSupplyCrate();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnSupplyCrate()
    {
        float xPos = Random.Range(minX, maxX);
        float zPos = Random.Range(minZ, maxZ);

        Vector3 spawnPos = new Vector3(xPos, spawnHeight, zPos);

        Instantiate(supplyCratePrefab, spawnPos, Quaternion.Euler(new Vector3(-90, 0, 0)));
    }
}
