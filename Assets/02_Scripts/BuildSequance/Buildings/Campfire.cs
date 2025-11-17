using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public GameObject fireEffect;
    public Light fireLight;

    private bool isActive = false;

    private void Start()
    {
        //건축 완성했을 때는 불이 꺼진 상태
        fireEffect.SetActive(false);
        fireLight.enabled = false;
    }
    public void ToggleFire()
    {
        isActive = !isActive;

        fireEffect.SetActive(isActive);
        fireLight.enabled = isActive;

    }

    
    
}
