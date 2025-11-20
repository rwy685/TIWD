using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    public Light insideLight;   // 텐트 내부를 밝히는 라이트

    private void Start()
    {
        if (insideLight != null)
            insideLight.enabled = false; // 기본은 꺼진 상태
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player만 반응하도록
        if (other.CompareTag("Player"))
        {
            insideLight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideLight.enabled = false;
        }
    }
}
