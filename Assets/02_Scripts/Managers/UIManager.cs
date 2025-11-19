using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Condition UI")]
    public Conditions hp;
    public Conditions hunger;
    public Conditions thirst;
    public Conditions stamina;

    private void Awake()
    {
        Instance = this;
    }

    public void Bind(PlayerCondition condition)
    {
        condition.playerHP = hp;
        condition.hunger = hunger;
        condition.thirst = thirst;
        condition.stamina = stamina;
    }
}

