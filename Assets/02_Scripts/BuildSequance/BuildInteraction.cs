using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInteraction : MonoBehaviour, IInteractable
{
    public BuildObject buildObject;
    
    public string GetInteractPrompt()
    {
        return "자원 투입 (E)";
    }

    public void OnInteract()
    {
        Player player = GameManager.Instance.characterManager.player;
        GameManager.Instance.buildManager.TryUseResource(player);
    }

}
