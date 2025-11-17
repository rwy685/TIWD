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
        buildObject.AddResource(buildObject.data.requirements[0].resource, 1);
        Debug.Log("자원 투입됨");
    }

}
