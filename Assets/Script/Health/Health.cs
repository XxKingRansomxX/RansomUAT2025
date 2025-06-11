using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float currentHealth = 100f;
    [SerializeField] private float maxHealth = 100f;
    public Image healthBarImage;
    [SerializeField] private bool isInstaKill = false;
    private bool isDead = false;

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        Death deathComponent = GetComponent<Death>();
        if (deathComponent != null)
        {
            deathComponent.Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (isInstaKill)
                InstaKill();
            else
                Die();
        }
        UpdateHealthBar();
    }

    public void InstaKill()
    {
        Die();
    }

    public void UpdateHealthBar()
    {
        if (healthBarImage != null)
            healthBarImage.fillAmount = currentHealth / maxHealth;
    }
}