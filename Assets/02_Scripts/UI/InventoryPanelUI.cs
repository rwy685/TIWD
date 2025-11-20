using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanelUI : MonoBehaviour
{
    [Header("Description UI")]
    public Image icon;
    public TMP_Text itemName;
    public TMP_Text itemDesc;
    public Button useButton;   // Use 버튼
    public Button discardButton;  // discard 추가됨

    private ItemSlot curSlot;

    // 슬롯 클릭 → 설명창 업데이트
    public void UpdateDescription(ItemSlot slot)
    {
        curSlot = slot;

        if (slot == null || slot.item == null)
        {
            ClearDescription();
            return;
        }

        // 아이콘 세팅
        icon.sprite = slot.item.inventoryIcon;
        icon.color = Color.white;

        // 텍스트
        itemName.text = slot.item.displayName;
        itemDesc.text = slot.item.displayDesc;

        // USE 버튼 세팅
        useButton.gameObject.SetActive(true);
        useButton.GetComponentInChildren<TMP_Text>().text = "사용";
        useButton.onClick.RemoveAllListeners();
        useButton.onClick.AddListener(OnUseButtonClicked);

        // DISCARD 버튼 세팅 (해제/버리기)
        discardButton.gameObject.SetActive(true);
        discardButton.onClick.RemoveAllListeners();
        discardButton.onClick.AddListener(OnDiscardButtonClicked);
    }

    // USE 버튼 클릭 행동
    void OnUseButtonClicked()
    {
        if (curSlot == null || curSlot.item == null)
            return;

        ItemData item = curSlot.item;

        switch (item.itemType)
        {
            case ItemType.Consumable:
                curSlot.inventory.TryUseItem(item);
                Debug.Log($"{item.displayName} 사용");

                InventoryUI.Instance.RefreshAllSlots();
                UpdateDescription(curSlot);
                break;

            case ItemType.Equipable:
                {
                    Debug.Log($"{item.displayName} 장착");

                    Equipment eq = GameManager.Instance.characterManager.player.GetComponent<Equipment>();
                    eq.EquipNew(item);

                    InventoryUI.Instance.RefreshAllSlots();
                    UpdateDescription(curSlot);
                    break;
                }

            default:
                Debug.Log($"{item.displayName}은 사용할 수 없습니다.");
                break;
        }
    }

    // Discard 버튼 클릭 행동 (장비 해제 , 소비/기타 버리기)
    void OnDiscardButtonClicked()
    {
        if (curSlot == null || curSlot.item == null)
            return;

        ItemData item = curSlot.item;

        // 장비아이템은 해제만 (삭제 없음)
        if (item.itemType == ItemType.Equipable)
        {
            Equipment eq = GameManager.Instance.characterManager.player.GetComponent<Equipment>();

            if (eq.curEquip != null)
            {
                eq.UnEquip();
                Debug.Log($"{item.displayName} 해제 완료");
            }

            InventoryUI.Instance.RefreshAllSlots();
            UpdateDescription(curSlot);
            return;
        }

        // 소비/기타 아이템은 버리기
        if (item.itemType == ItemType.Consumable || item.itemType == ItemType.Resource)
        {
            curSlot.quantity--;

            if (curSlot.quantity <= 0)
                curSlot.item = null;

            Debug.Log($"{item.displayName} 버림");

            InventoryUI.Instance.RefreshAllSlots();
            UpdateDescription(curSlot);
        }
    }

    // 빈 슬롯 클릭 → 초기화
    public void ClearDescription()
    {
        icon.sprite = null;
        icon.color = new Color(1, 1, 1, 0);

        itemName.text = "";
        itemDesc.text = "";

        useButton.onClick.RemoveAllListeners();
        useButton.gameObject.SetActive(false);

        discardButton.onClick.RemoveAllListeners();
        discardButton.gameObject.SetActive(false);
    }
}
