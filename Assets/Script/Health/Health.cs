using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float currentHealth; // Current health value, can be modified during gameplay

    [SerializeField]
    private float maxHealth; // Maximum health value

    [SerializeField] private GameOverStageComplete gameOver; // Correctly named and initialized field

    private void Die()
    {
        // Call MeteorDeath.Explode if present
        MeteorDeath meteorDeath = GetComponent<MeteorDeath>();
        if (meteorDeath != null)
        {
            meteorDeath.Explode();
            return; // Prevent further logic if it's a meteor
        }

        // Correctly call ShowGameOver method on gameOver
        if (gameOver != null)
        {
            gameOver.ShowGameOver();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialization logic if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic if needed
    }

    public void Heal(float amount)
    {
        currentHealth = currentHealth + amount; // Heal the character by the specified amount 

        if (currentHealth > maxHealth) // Ensure current health does not exceed maximum health
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth = currentHealth - amount; // Reduce current health by the specified amount

        if (currentHealth <= 0)
        {
            currentHealth = 0; // Tell the object to die

            InstaKill();
        }
    }

    public void InstaKill()
    {
        Death deathComponent = GetComponent<Death>(); // Get the Death component attached to the GameObject

        if (deathComponent != null) // Check if the Death component exists
        {
            deathComponent.Die(); // Call the Die method on the Death component
        }
    }

    public bool IsAlive() // This method checks if the object is alive
    {
        if (currentHealth > 0)
        {
            return true;
        }

        return false; // Otherwise, the object is not alive
    }
}