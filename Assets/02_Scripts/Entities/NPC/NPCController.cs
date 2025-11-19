using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    [Header("NPC Info")]
    public string npcName;

    [TextArea(2, 5)]
    public string[] dialogues;

    [Header("Tutorial Item")]
    public ItemData rewardItem;
    public int rewardAmount = 1;
    public bool itemGiven = false;

    private void Start()
    {
        UIManager.Instance.OnDialogueClosed += HandleDialogueClosed;
    }

    private void OnDestroy()
    {
        if (UIManager.Instance != null)
            UIManager.Instance.OnDialogueClosed -= HandleDialogueClosed;
    }

    public string GetInteractPrompt()
    {
        return $"{npcName}와 대화하기 (E)";
    }

    public void OnInteract()
    {
        if (UIManager.Instance.IsDialogueOpen)
            return;

        UIManager.Instance.ShowDialogue(npcName, dialogues);
    }

    private void HandleDialogueClosed()
    {
        if (!itemGiven)
        {
            Debug.Log($"{npcName} 튜토리얼 아이템 지급");

            Inventory playerInv = GameManager.Instance.characterManager.player.inventory;
            playerInv.AddItemToInventory(rewardItem, 1);

            itemGiven = true;
        }
    }
}