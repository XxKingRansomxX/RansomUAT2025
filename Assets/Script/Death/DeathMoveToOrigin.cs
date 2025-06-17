using UnityEngine;

public class DeathMoveToOrigin : Death
{
    private float currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DieInternal();
        }
        UpdateHealthBar();
    }

    private void DieInternal()
    {
        Death deathComponent = GetComponent<Death>();
        if (deathComponent != null)
            deathComponent.Die();
    }

    public override void Die()
    {
        // Move the GameObject this script is attached to to the origin (0, 0, 0)
        gameObject.transform.position = Vector3.zero;
    }

    private void UpdateHealthBar()
    {
        // Implementation for updating the health bar goes here
    }
}
