using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform slotGrid;      // ItemSlot 들이 배치될 그리드 UI
    public ItemSlot[] itemSlots;   // 인벤토리 내의 모든 아이템 슬롯

    private Transform throwPos;    // 아이템을 버릴 위치

    void Start()
    {
        throwPos = GameManager.Instance.characterManager.player.transform;
        
        GameManager.Instance.characterManager.player.addItem += AddItem;

        itemSlots = new ItemSlot[slotGrid.childCount];

        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = slotGrid.GetChild(i).GetComponent<ItemSlot>();
            itemSlots[i].index = i;
            itemSlots[i].inventory = this;
        }
    }

    // 획득한 아이템을 인벤토리에 추가하는 함수
    void AddItem()
    {
        ItemData curItem = GameManager.Instance.characterManager.player.acquiredItem;

        // Case #1. 현재 획득한 아이템이 중첩 가능한 아이템인 경우
        if (curItem.isStackable)
        {
            ItemSlot curSlot = GetItemSlot(curItem);

            if (curSlot != null)
            {
                curSlot.quantity++;
                // TODO : 아이템 슬롯 UI 갱신
                GameManager.Instance.characterManager.player.acquiredItem = null;
                return;
            }
        }

        // Case #2. 중첩 불가능 아이템이거나, 처음 획득한 아이템인 경우
        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = curItem;
            emptySlot.quantity = 1;
            // TODO : 아이템 슬롯 UI 갱신
            GameManager.Instance.characterManager.player.acquiredItem = null;
            return;
        }

        // Case #3. 인벤토리가 가득 찬 경우
        ThrowItem(curItem);

        GameManager.Instance.characterManager.player.acquiredItem = null;
    }

    // 인벤토리 내에 이미 존재하는 아이템 슬롯을 반환하는 함수
    ItemSlot GetItemSlot(ItemData data)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == data && itemSlots[i].quantity < data.maxStack)
                return itemSlots[i];
        }

        return null;
    }

    // 인벤토리 내에 비어있는 아이템 슬롯을 반환하는 함수
    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
                return itemSlots[i];
        }

        return null;
    }

    void ThrowItem(ItemData data)
    {
        Instantiate(data.itemPrefab, throwPos.position, Quaternion.Euler(Vector3.one * Random.value * 360));
    }
}
