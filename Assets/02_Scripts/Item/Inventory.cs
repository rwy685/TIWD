using UnityEngine;

public class Inventory : MonoBehaviour
{
    // 플레이어 캐싱용 변수
    [SerializeField] private Player player;

    public Transform slotGrid;      // ItemSlot 들이 배치될 그리드 UI
    public ItemSlot[] itemSlots;   // 인벤토리 내의 모든 아이템 슬롯

    private Transform throwPos;    // 아이템을 버릴 위치

    void Start()
    {
        player = GameManager.Instance.characterManager.player;

        throwPos = player.transform;

        player.controller.inventory += Toggle;
        player.addItem += AddItem;

        gameObject.SetActive(false);

        itemSlots = new ItemSlot[slotGrid.childCount];

        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = slotGrid.GetChild(i).GetComponent<ItemSlot>();
            itemSlots[i].index = i;
            itemSlots[i].inventory = this;
        }

        player.inventory = this;

    }

    // 인벤토리창 활성화/비활성화 함수
    public void Toggle()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    // 획득한 아이템을 인벤토리에 추가하는 함수
    void AddItem()
    {
        ItemData curItem = player.acquiredItem;

        // Case #1. 현재 획득한 아이템이 중첩 가능한 아이템인 경우
        if (curItem.isStackable)
        {
            ItemSlot curSlot = GetItemSlot(curItem);

            if (curSlot != null)
            {
                curSlot.quantity++;
                // 테스트용 UI 갱신
                curSlot.SetUI();
                player.acquiredItem = null;
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
            // 테스트용 UI 갱신
            emptySlot.SetUI();
            player.acquiredItem = null;
            return;
        }

        // Case #3. 인벤토리가 가득 찬 경우
        ThrowItem(curItem);

        player.acquiredItem = null;
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

    // 인벤토리 재고 확인용
    public bool Has(ItemData item, int amount)
    {
        int total = 0;
        foreach (var slot in itemSlots)
        {
            if (slot.item == item)
                total += slot.quantity;
        }

        return total >= amount;
    }

    // 인벤토리에서 아이템 소비 (건축용)

    public bool ConsumeMultiple(ItemData item, int amount)
    {
        int remaining = amount;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == item)
            {
                int use = Mathf.Min(itemSlots[i].quantity, remaining); // 여러 슬롯에 나눠져있어도 같은 아이템이면 소비
                itemSlots[i].quantity -= use;
                remaining -= use;

                if (itemSlots[i].quantity == 0)
                    itemSlots[i].item = null;

                if (remaining <= 0)
                    return true;
            }
        }

        return false;
    }

    // 인벤토리에 제작 아이템 추가
    public bool AddItemToInventory(ItemData item, int amount = 1)
    {
        // 1) 중첩 가능 아이템인 경우
        if (item.isStackable)
        {
            // 이미 존재하는 슬롯 검색
            ItemSlot slot = GetItemSlot(item);

            if (slot != null)
            {
                // 현재 슬롯에 더 넣을 수 있는 만큼 계산
                int space = item.maxStack - slot.quantity;
                int addCount = Mathf.Min(space, amount);

                slot.quantity += addCount;
                amount -= addCount;

                // TODO: UI 갱신
            }
        }

        // 2) 남은 개수가 있다면 빈 슬롯에 채우기
        while (amount > 0)
        {
            ItemSlot emptySlot = GetEmptySlot();
            if (emptySlot == null)
                return false; // 인벤토리가 가득 차서 일부는 못 넣음 (필요하면 땅에 드랍도 가능)

            int putCount = Mathf.Min(item.isStackable ? item.maxStack : 1, amount);

            emptySlot.item = item;
            emptySlot.quantity = putCount;

            amount -= putCount;

            // TODO: UI 갱신
        }

        return true;
    }

    //*빌드모드용 모든슬롯의 같은 ItemData 갯수 합산 (건축용)
    public int Count(ItemData item)
    {
        int total = 0;

        foreach (var slot in itemSlots)
        {
            if (slot.item == item)
                total += slot.quantity;
        }

        return total;
    }

    //
    // 소비아이템 사용
    //

    // 아이템 1개 소비
    public bool ConsumeOne(ItemData item)
    {
        return ConsumeMultiple(item, 1);
    }

    // Consumable 타입일 때만 소비
    public bool TryUseItem(ItemData item)
    {
        // 1) 소비 가능한 타입인지 확인
        if (item.itemType != ItemType.Consumable)
        {
            Debug.LogWarning($"TryUseItem 실패: {item.displayName} 은 Consumable 타입이 아님!");
            return false;
        }

        // 2) 인벤토리에 존재하는지 확인
        if (!Has(item, 1))
            return false;

        // 3) 실제 소비
        return ConsumeOne(item);
    }


}
