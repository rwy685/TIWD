using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Time UI")]
    public TMP_Text timeText;
    public TMP_Text dayText;

    private DayNightCycle dayNightCycle;

    private void Awake()
    {
        Instance = this;

        dayNightCycle = FindObjectOfType<DayNightCycle>();
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
    public CanvasGroup dialogueGroup;
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
        dialogueGroup.alpha = 0;
        dialogueGroup.transform.localScale = Vector3.one * 0.8f;

        dialogueGroup.DOFade(1, 0.25f);
        dialogueGroup.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBack);

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
        // 닫히는 애니메이션 (페이드 + 축소)
        dialogueGroup.DOFade(0, 0.2f);
        dialogueGroup.transform.DOScale(0.8f, 0.2f).OnComplete(() =>
        {
            dialoguePanel.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // NPCController.cs로 이벤트 전달
            OnDialogueClosed?.Invoke();
        });
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
        {
            UpdateTimeUI();
        }

        void UpdateTimeUI()
        {
            if (dayNightCycle == null) return;

            float t = dayNightCycle.time;      // 낮/밤 비율
            int day = GameManager.Instance.day;  // 날짜는 GameManager

            // 시간을 실제 시간으로 변환
            float totalMinutes = t * 24f * 60f;
            int hour = Mathf.FloorToInt(totalMinutes / 60f);
            int minute = Mathf.FloorToInt(totalMinutes % 60);

            string ampm = (hour < 12) ? "AM" : "PM";
            int displayHour = hour % 12;
            if (displayHour == 0) displayHour = 12;

            timeText.text = $"{ampm} {displayHour:D2}:{minute:D2}";
            dayText.text = $"DAY {day}";
        }
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
