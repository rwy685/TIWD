using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    public void Init()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
