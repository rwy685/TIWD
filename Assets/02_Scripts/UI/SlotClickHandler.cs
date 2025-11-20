using UnityEngine;

public class SlotClickHandler : MonoBehaviour
{
    public int index;

    public void Click()
    {
        GameManager.Instance.inventoryUI.OnSlotClicked(index);
    }
}