using UnityEngine;


public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UIConditions uiConditions;

    Conditions playerHP => uiConditions.playerHP;
    Conditions stamina => uiConditions.stamina;
    Conditions hunger => uiConditions.hunger;
    Conditions thirst => uiConditions.thirst;

    public float starvingDamage;
    public float thirstyDamage;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        uiConditions.Init();
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

    public void TakePhysicalDamage(int damage)
    {
        playerHP.Minus(damage);        
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
        throw new System.NotImplementedException();
    }
}
