using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

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
        throw new System.NotImplementedException();
    }
}
