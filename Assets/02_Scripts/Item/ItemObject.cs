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

    public void Use()
    {
        if (itemData.recoveryData != null)
        {
            foreach (var type in itemData.recoveryData)
            {
                if (type.consumableType == ConsumableType.Health)
                {
                    GameManager.Instance.characterManager.player.condition.Heal(type.recoveryAmount);
                }
                if (type.consumableType == ConsumableType.Hunger)
                {
                    GameManager.Instance.characterManager.player.condition.Drink(type.recoveryAmount);
                }
                if (type.consumableType == ConsumableType.Thirst)
                {
                    GameManager.Instance.characterManager.player.condition.Eat(type.recoveryAmount);
                }
            }
        }
    }
}
