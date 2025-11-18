using UnityEngine;
using UnityEngine.UI;

public class Conditions : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public float startValue;
    public float passiveValue;
    public Image uiBar;



    public void Start()
    {
        curValue = startValue;
    }


    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Minus(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        if (maxValue <= 0f)
            return 0f;

        return curValue / maxValue;
    }
}
