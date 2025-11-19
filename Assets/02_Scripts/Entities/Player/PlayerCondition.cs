using UnityEngine;



public class PlayerCondition : MonoBehaviour, IDamagable
{
    //public UIConditions uiConditions;

    //public Conditions playerHP => uiConditions.playerHP;
    //public Conditions stamina => uiConditions.stamina;
    //public Conditions hunger => uiConditions.hunger;
    //public Conditions thirst => uiConditions.thirst;

    //UIConditions대신 UIManager로 바꾸며 PlayerCondition이 Conditions를 참조하도록 변경
    [Header("Condition References")]
    public Conditions playerHP;
    public Conditions stamina;
    public Conditions hunger;
    public Conditions thirst;

    public float starvingDamage;
    public float thirstyDamage;

    private float defaultStaminaRecover;
    private float defaultThirstConsume;

    //호출 순서 문제로 Awake에서 Start로 바꿨습니다..
    private void Start()
    {
        UIManager.Instance.Bind(this);

        defaultStaminaRecover = stamina.passiveValue;
        defaultThirstConsume = thirst.passiveValue;
    }

    private void Update()
    {
        hunger.Minus(hunger.passiveValue * Time.deltaTime);
        thirst.Minus(thirst.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue <= 0)
        {
            playerHP.Minus(starvingDamage * Time.deltaTime);
        }
        else if (hunger.curValue >= 70) // 허기가 70 이상일경우 자동회복
        {
            playerHP.Add(playerHP.passiveValue * Time.deltaTime);
        }

        if (thirst.curValue <= 0)
        {
            playerHP.Minus(thirstyDamage * Time.deltaTime);
        }

        if (playerHP.curValue <= 0)
        {
            Die();
        }

        
    }


    public void Heal(float amount)
    {
        playerHP.Add(amount);
    }

    public void Drink(float amount)
    {
        thirst.Add(amount);
    }

    public void Eat(float amount)
    { 
        hunger.Add(amount);        
    }

    public void Starving()
    {
        
    }

    public void Die()
    {

        Time.timeScale = 0f;
        Debug.Log("D gym");
    }

    public void TakePhysicalDamage(float damage)
    {
        playerHP.Minus(damage);
    }

    public bool UseStamina(float amount)    // 한 번의 동작 (공격, 점프)에 사용하면 됩니다
    {
        if (stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Minus(amount);
        return true;
    }

    public void RecoverOff()    // 스태미너 자동회복을 0으로 만드는 함수
    {
        stamina.passiveValue = 0f;
    }

    public void RecoverOn()     // 스태미너 자동회복의 기본값으로 다시 선언하는 함수
    {
        stamina.passiveValue = defaultStaminaRecover;
    }
}
