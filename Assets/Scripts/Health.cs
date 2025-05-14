using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //UI
    public Image healthBar;

    //Variables
    public int maxHealth = 30;
    public int currentHealth;

    public UnityEvent onDeath;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Ensure health doesn't go below 0 or above 9
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            onDeath?.Invoke();
        }
    }

    public void HealthRegen()
    {
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

}
