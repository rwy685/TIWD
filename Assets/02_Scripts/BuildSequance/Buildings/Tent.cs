using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour, IInteractable
{
    public Light insideLight;   // 텐트 내부를 밝히는 라이트
    public BuildData buildData;
    private bool isActive = false;

    private void Start()
    {
        if (insideLight != null)
            insideLight.enabled = false; // 기본은 꺼진 상태
    }

    public void ToggleLight()
    {
        isActive = !isActive;

        insideLight.enabled = isActive;
    }

    public string GetInteractPrompt()
    {
        string prompt = $"{buildData.displayName}\n{buildData.displayDesc}";
        return prompt;
    }

    public void OnInteract()
    {
        ToggleLight();
    }

}
