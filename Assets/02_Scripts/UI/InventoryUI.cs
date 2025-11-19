using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    void Awake()
    {
        Instance = this;
    }

    public void GiveTutorialItem()
    {
        Debug.Log("튜토리얼 아이템을 받았다");
    }
}
