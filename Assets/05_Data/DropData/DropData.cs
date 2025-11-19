using UnityEngine;

[CreateAssetMenu(fileName = "Drop", menuName = "New DropData")]
public class DropData : ScriptableObject
{
    [Header("Item Drop Info")]
    public GameObject dropPrefab;
    public int minDropCount;
    public int maxDropCount;
    [Range(0f, 100f)] public float dropChance; // 0 % ~ 100 %
}
