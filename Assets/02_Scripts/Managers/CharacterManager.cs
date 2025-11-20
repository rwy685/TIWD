using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;

    public Player player;

    public void Init()
    {
        Spawn();
    }

    private void Spawn()
    {
        GameObject playerObject = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        player = playerObject.GetComponent<Player>();
    }
}
