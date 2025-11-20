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

        // 버튼 설정
        actionButton.gameObject.SetActive(true);
        actionButton.GetComponentInChildren<TMP_Text>().text = "사용";

        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(OnUseButtonClicked);
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
                Debug.Log($"{item.displayName} 장착 (Equipable)");
                break;

            default:
                Debug.Log($"{item.displayName}은 사용할 수 없습니다.");
                break;
        }
    }

    // 빈 슬롯 클릭 → 초기화
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
