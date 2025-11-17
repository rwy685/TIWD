using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Inventory inventory;

    public ItemData item;   // 현재 슬롯에 들어있는 아이템 정보
    public int quantity;    // 현재 슬롯에 들어있는 아이템의 개수
    public int index;       // 슬롯의 인덱스 번호
}
