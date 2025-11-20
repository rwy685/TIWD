using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanelUI : MonoBehaviour
{
    [Header("Description UI")]
    public Image icon;
    public TMP_Text itemName;
    public TMP_Text itemDesc;
    public Button actionButton;

    private ItemSlot curSlot;

    // ================================
    // 🔥 슬롯 클릭 → 설명창 업데이트
    // ================================
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

        // 텍스트 세팅
        itemName.text = slot.item.displayName;
        itemDesc.text = slot.item.displayDesc;

        // 버튼 활성화
        actionButton.gameObject.SetActive(true);
        actionButton.GetComponentInChildren<TMP_Text>().text = "사용";

        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(OnUseButtonClicked);
    }

    // ================================
    // 🔥 [사용] 버튼 클릭 행동 (B안)
    // ================================
    void OnUseButtonClicked()
    {
        if (curSlot == null || curSlot.item == null)
            return;

        ItemData item = curSlot.item;

        switch (item.itemType)
        {
            case ItemType.Consumable:
                // 소비 아이템 → 먹기 / 회복
                curSlot.inventory.TryUseItem(item);
                Debug.Log($"{item.displayName} 사용 (Consumable)");

                InventoryUI.Instance.RefreshAllSlots();
                UpdateDescription(curSlot);
                break;

            case ItemType.Equipable:
                // 장비 아이템 → 장착 로직 (원하면 확장해줌)
                Debug.Log($"{item.displayName} 장착 완료 (Equipable)");
                // TODO: 장비 시스템과 연결 가능
                break;

            case ItemType.Resource:
                // 자원 아이템 → 사용 불가
                Debug.Log($"{item.displayName}은(는) 사용할 수 없는 아이템입니다 (Resource)");
                break;
        }
    }

    // ================================
    // 🔥 아이템 없는 슬롯 클릭 시 초기화
    // ================================
    public void ClearDescription()
    {
        icon.sprite = null;
        icon.color = new Color(1, 1, 1, 0);

        itemName.text = "";
        itemDesc.text = "";

        actionButton.onClick.RemoveAllListeners();
        actionButton.gameObject.SetActive(false);
    }
}
