using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [Header("References")]
    public Inventory inventory;
    public Transform slotParent;
    public GameObject slotPrefab;

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

 
    // 슬롯 자동 생성
    void GenerateSlots()
    {
        slotIcons = new Image[slotCount];
        slotTexts = new TMP_Text[slotCount];
        inventory.itemSlots = new ItemSlot[slotCount];

        for (int i = 0; i < slotCount; i++)
        {
            // 슬롯 프리팹 생성
            GameObject slotObj = Instantiate(slotPrefab, slotParent);

            Image icon = slotObj.transform.Find("Icon").GetComponent<Image>();
            TMP_Text qty = slotObj.transform.Find("QuantityText").GetComponent<TMP_Text>();

            slotIcons[i] = icon;
            slotTexts[i] = qty;

            // 슬롯 클릭 핸들러
            SlotClickHandler click = slotObj.GetComponent<SlotClickHandler>();
            if (click == null)
                click = slotObj.AddComponent<SlotClickHandler>();
            click.index = i;

            // ItemSlot 생성
            ItemSlot newSlot = slotObj.GetComponent<ItemSlot>();
            if (newSlot == null)
                newSlot = slotObj.AddComponent<ItemSlot>();

            newSlot.index = i;
            newSlot.quantity = 0;
            newSlot.item = null;
            newSlot.inventory = inventory;

            inventory.itemSlots[i] = newSlot;

            // 기본 비활성화
            icon.color = new Color(1, 1, 1, 0);
            qty.text = "";
        }
    }

  
    // 슬롯 갱신 + 필터 적용
    public void RefreshAllSlots()
    {
        if (inventory.itemSlots == null)
            return;

        for (int i = 0; i < inventory.itemSlots.Length; i++)
        {
            ItemSlot slot = inventory.itemSlots[i];

            // 필터 통과 여부
            bool visible = PassFilter(slot);

            if (!visible || slot.item == null)
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

    // 필터 체크
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


    //  슬롯 클릭 → 설명창 갱신
    public void OnSlotClicked(int index)
    {
        ItemSlot slot = inventory.itemSlots[index];

        // UIManager → inventoryPanel 안에서 InventoryPanelUI 가져오기
        InventoryPanelUI desc = UIManager.Instance.inventoryPanel.GetComponent<InventoryPanelUI>();
        desc.UpdateDescription(slot);
    }


    // 🔥 필터 버튼
    public void OnClickAllFilter() => SetFilter(FilterType.All);
    public void OnClickEquipFilter() => SetFilter(FilterType.Equip);
    public void OnClickConsumeFilter() => SetFilter(FilterType.Consumable);
    public void OnClickResourceFilter() => SetFilter(FilterType.Resource);

    void SetFilter(FilterType filter)
    {
        currentFilter = filter;
        RefreshAllSlots();
    }
}
