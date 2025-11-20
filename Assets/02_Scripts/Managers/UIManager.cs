using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // ================================================
    // === Condition UI (HP / Hunger / Thirst / Stamina)
    // ================================================
    [Header("=== Condition UI ===")]
    public Conditions HP;
    public Conditions Hunger;
    public Conditions Thirst;
    public Conditions Stamina;

    public void Bind(PlayerCondition condition)
    {
        condition.playerHP = HP;
        condition.hunger = Hunger;
        condition.thirst = Thirst;
        condition.stamina = Stamina;
    }


    // ================================================
    // =============== Dialogue UI =====================
    // ================================================
    [Header("=== Dialogue UI ===")]
    public GameObject dialoguePanel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button nextBtn;
    public Button closeBtn;

    private string[] lines;
    private int index;

    // NPCController가 구독하는 이벤트
    public event System.Action OnDialogueClosed;

    public bool IsDialogueOpen => dialoguePanel != null && dialoguePanel.activeSelf;


    // 외부에서 대화 시작
    public void ShowDialogue(string npcName, string[] dialogueLines)
    {
        StartDialogue(npcName, dialogueLines);
    }

    public void StartDialogue(string npcName, string[] dialogueLines)
    {
        lines = dialogueLines;
        index = 0;

        nameText.text = npcName;
        dialogueText.text = lines[index];

        dialoguePanel.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void NextDialogue()
    {
        index++;

        if (index < lines.Length)
        {
            dialogueText.text = lines[index];
        }
        else
        {
            CloseDialogue();
        }
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // NPCController.cs가 구독한 이벤트 호출
        OnDialogueClosed?.Invoke();
    }


    [Header("=== Inventory / Crafting UI ===")]
    public GameObject inventorycraftingWindow;   // InventoryCraftingWindow
    public GameObject inventoryPanel;    // InventoryPanel
    public GameObject craftingPanel;     // CraftingPanel

    public bool IsInventoryOpen => inventorycraftingWindow != null && inventorycraftingWindow.activeSelf;

    private void Start()
    {
        GameManager.Instance.characterManager.player.controller.inventory += ToggleInventory;
    }

    private void Update()
    {
        //// ESC로 닫기
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (IsInventoryOpen)
        //        CloseInventory();
        //    else if (IsDialogueOpen)
        //        CloseDialogue();
        //}
    }

    public void ToggleInventory()
    {
        if (IsDialogueOpen) return; // 대화 중엔 열리지 않음

        if (IsInventoryOpen)
            CloseInventory();
        else
            OpenInventory();
    }

    public void OpenInventory()
    {
        inventorycraftingWindow.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseInventory()
    {
        inventorycraftingWindow.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // 탭 전환
    public void OpenInventoryTab()
    {
        inventoryPanel.SetActive(true);
        craftingPanel.SetActive(false);
    }

    public void OpenCraftingTab()
    {
        inventoryPanel.SetActive(false);
        craftingPanel.SetActive(true);
    }

    // 다른 UI와 충돌 체크
    public bool IsAnyUIOpen()
    {
        return IsDialogueOpen || IsInventoryOpen;
    }

    [Header("=== Prompt UI ===")]
    public GameObject promptPanel;
    public TMP_Text promptText;

    public void PromptSet(bool active, string text = "")
    {
        if (promptPanel != null)
            promptPanel.SetActive(active);

        if (promptText != null)
            promptText.text = text;
    }
}
