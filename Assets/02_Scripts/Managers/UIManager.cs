using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("=== Condition UI ===")]
    public Conditions hp;
    public Conditions hunger;
    public Conditions thirst;
    public Conditions stamina;

    [Header("=== Dialogue UI ===")]
    public GameObject dialoguePanel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button nextBtn;
    public Button closeBtn;

    private string[] lines;
    private int index;

    public event Action OnDialogueClosed;

    private void Awake()
    {
        Instance = this;

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
    }

    public void Bind(PlayerCondition condition)
    {
        hp = condition.playerHP;
        hunger = condition.hunger;
        thirst = condition.thirst;
        stamina = condition.stamina;
    }

    public void ShowDialogue(string npcName, string[] npcLines)
    {
        dialoguePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        nameText.text = npcName;

        lines = npcLines;
        index = 0;
        dialogueText.text = lines[index];

        nextBtn.onClick.RemoveAllListeners();
        closeBtn.onClick.RemoveAllListeners();

        nextBtn.onClick.AddListener(NextLine);
        closeBtn.onClick.AddListener(CloseDialogue);
    }

    private void NextLine()
    {
        index++;

        if (index >= lines.Length)
        {
            CloseDialogue();
            return;
        }

        dialogueText.text = lines[index];
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);

        OnDialogueClosed?.Invoke();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public bool IsDialogueOpen => dialoguePanel.activeSelf;
}
