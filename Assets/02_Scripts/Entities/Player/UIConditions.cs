using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditions : MonoBehaviour
{
    public Conditions playerHP;
    public Conditions stamina;
    public Conditions hunger;
    public Conditions thirst;

    public void Init()
    {
        playerHP.Init();
        stamina.Init();
        hunger.Init();
        thirst.Init();
    }
}


