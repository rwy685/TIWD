using UnityEngine;

public class SlotClickHandler : MonoBehaviour
{
    public int index;

    public void Click()
    {
        InventoryUI.Instance.OnSlotClicked(index);
    }
}