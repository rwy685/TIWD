using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [Header("References")]
    public Inventory inventory;      // 플레이어 인벤토리
    public Transform slotParent;     // 슬롯을 담을 GridLayoutGroup
    public GameObject slotPrefab;    // Slot 프리팹

    [Header("Generated UI")]
    public Image[] slotIcons;
    public TMP_Text[] slotTexts;

    [Header("Filter")]
    public FilterType currentFilter = FilterType.All;
    public enum FilterType { All, Equip, Consumable, Resource }
   

    public int slotCount = 16;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateSlots();
        RefreshAllSlots();
    }

    // =====================================
    // 🔥 슬롯 자동 생성
    // =====================================
    void GenerateSlots()
    {
        slotIcons = new Image[slotCount];
        slotTexts = new TMP_Text[slotCount];

        inventory.itemSlots = new ItemSlot[slotCount];

        for (int i = 0; i < slotCount; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotParent);

            Image icon = slotObj.transform.Find("Icon").GetComponent<Image>();
            TMP_Text qty = slotObj.transform.Find("QuantityText").GetComponent<TMP_Text>();

            slotIcons[i] = icon;
            slotTexts[i] = qty;

            // SlotClickHandler 자동 추가
            SlotClickHandler click = slotObj.GetComponent<SlotClickHandler>();
            if (click == null)
                click = slotObj.AddComponent<SlotClickHandler>();
            click.index = i;

            // ItemSlot 자동 생성
            ItemSlot newSlot = slotObj.AddComponent<ItemSlot>();
            newSlot.index = i;
            newSlot.quantity = 0;
            newSlot.item = null;
            newSlot.inventory = inventory;
            inventory.itemSlots[i] = newSlot;

            // 기본 비활성화 처리
            icon.color = new Color(1, 1, 1, 0);
            qty.text = "";
        }
    }

    // =====================================
    // 🔥 슬롯 갱신 + 필터 적용
    // =====================================
    public void RefreshAllSlots()
    {
        for (int i = 0; i < inventory.itemSlots.Length; i++)
        {
            ItemSlot slot = inventory.itemSlots[i];

            // 필터에 맞지 않으면 감추기
            if (!PassFilter(slot))
            {
                slotIcons[i].sprite = null;
                slotIcons[i].color = new Color(1, 1, 1, 0);
                slotTexts[i].text = "";
                continue;
            }

            // 빈 슬롯
            if (slot.item == null)
            {
                slotIcons[i].sprite = null;
                slotIcons[i].color = new Color(1, 1, 1, 0);
                slotTexts[i].text = "";
                continue;
            }

            // 아이템 표시
            slotIcons[i].sprite = slot.item.inventoryIcon;
            slotIcons[i].color = Color.white;

            slotTexts[i].text = slot.quantity > 1 ? slot.quantity.ToString() : "";
        }
    }

    // 필터 함수
    private bool PassFilter(ItemSlot slot)
    {
        if (currentFilter == FilterType.All)
            return true;

        if (slot.item == null)
            return false;

        switch (currentFilter)
        {
            case FilterType.Equip:
                return slot.item.itemType == ItemType.Equipable;

            case FilterType.Consumable:
                return slot.item.itemType == ItemType.Consumable;

            case FilterType.Resource:
                return slot.item.itemType == ItemType.Resource;
        }

        return true;
    }

    // =====================================
    // 🔥 슬롯 클릭 시 설명창 업데이트
    // =====================================
    public void OnSlotClicked(int index)
    {
        ItemSlot slot = inventory.itemSlots[index];

        InventoryPanelUI desc = UIManager.Instance.inventoryPanel.GetComponent<InventoryPanelUI>();
        desc.UpdateDescription(slot);
    }

    // =====================================
    // 🔥 필터 버튼 연결 함수들
    // =====================================
    public void OnClickEquipFilter() => SetFilter(FilterType.Equip);
    public void OnClickConsumeFilter() => SetFilter(FilterType.Consumable);
    public void OnClickResourceFilter() => SetFilter(FilterType.Resource);
    public void OnClickAllFilter() => SetFilter(FilterType.All);

    void SetFilter(FilterType filter)
    {
        currentFilter = filter;
        RefreshAllSlots();
    }
}
