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

    //호출 순서 문제로 Awake에서 Start로 바꿨습니다..
    private void Start()
    {
        UIManager.Instance.Bind(this);
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
        else if (hunger.curValue >= 380) //fix예정
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
}
