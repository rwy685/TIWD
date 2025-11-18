using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 5.0f;
    [SerializeField] private float spawnHeight = 10.0f;
    [SerializeField] private float minX = -7.5f;       // 맵 크기 따라 조절
    [SerializeField] private float maxX = 7.5f;        // 맵 크기 따라 조절
    [SerializeField] private float minZ = -7.5f;       // 맵 크기 따라 조절
    [SerializeField] private float maxZ = 7.5f;        // 맵 크기 따라 조절

    [Header("보급 상자 세팅")]
    [SerializeField] private GameObject supplyCratePrefab;

    /* // TODO : 리소스 폴더에서 프리팹 로드하는 방식으로 변경하려면 주석 해제
    private void Awake()
    {
        if (supplyCratePrefab == null)
        {
            supplyCratePrefab = Resources.Load<GameObject>("Prefabs/Item/SupplyCrate");
        }
    }*/

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
