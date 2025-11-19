using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    void Awake()
    {
        Instance = this;
    }
}
