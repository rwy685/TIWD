using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI promptText;

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

    public void PromptSet(Interaction interaction)
    {
        interaction.promptText = promptText;
    }
}

