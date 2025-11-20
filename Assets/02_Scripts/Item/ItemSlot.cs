using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [Header("UI 오브젝트")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI itemText;

    public Inventory inventory;

    // TODO :GameManager.Instance.InventoryUI 작성 후, 윗줄 지워주시고, 주석 해제해주세요!
    //public GameManager.Instance.InventoryUI inventoryUI;

    public ItemData item;   // 현재 슬롯에 들어있는 아이템 정보
    public int quantity;    // 현재 슬롯에 들어있는 아이템의 개수
    public int index;       // 슬롯의 인덱스 번호

    // 테스트용 아이템 슬롯 UI 갱신
    public void SetUI()
    {
        iconImage.color = new Color(1, 1, 1, 1);
        iconImage.sprite = item != null ? item.inventoryIcon : null;
        itemText.text = item != null ? $"{item.displayName} x {quantity}" : "Empty";
    }
}
