using UnityEngine;


public interface IDamagable
{
    void TakePhysicalDamage(int damage);
}
public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UIConditions uiConditions;

    Conditions playerHP { get { return uiConditions.playerHP; } }
    Conditions stamina { get { return uiConditions.stamina; } }
    Conditions hunger { get { return uiConditions.hunger; } }
    Conditions thirst { get { return uiConditions.thirst; } }

    public float starvingDamage;
    public float thirstyDamage;

    private void Update()
    {
        hunger.Minus(hunger.passiveValue * Time.deltaTime);
        thirst.Minus(thirst.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue <= 0)
        { 
            playerHP.Minus(starvingDamage * Time.deltaTime);
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
}
