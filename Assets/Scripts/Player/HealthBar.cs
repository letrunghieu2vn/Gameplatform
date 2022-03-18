using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillbar;
    public float health;
    private Enemy EnemyDamage;

    //100 health => 1 fill amount
    //45 health => 0.45 fill amount 

    public void LoseHealth(float value)
    {
        //Do nothing if you are out of health
        if (health <= 0)
            return;
        //Reduce the health 
        health -= value;
        //Refresh the UI fillbar
        fillbar.fillAmount = health / 100;
        // Check if your health is zero or less => Dead
        if(health<=0)
        {
            Debug.Log("YOU DIED");
        }

    }

    private void Update()
    {  
        if(health<= 0)
        {
            UImanager.instance.GameOver();

        }

    }

    public void TakeDamage(float EnemyDamage)
    {
        LoseHealth(EnemyDamage);
    }

}
