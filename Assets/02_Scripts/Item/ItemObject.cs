using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData itemData;
    
    public string GetInteractPrompt()
    {
        string prompt = $"{itemData.displayName}\n{itemData.displayDesc}";
        return prompt;
    }

    public void OnInteract()
    {
        GameManager.Instance.characterManager.player.acquiredItem = itemData;
        GameManager.Instance.characterManager.player.addItem?.Invoke();
        Destroy(gameObject);
    }
}
