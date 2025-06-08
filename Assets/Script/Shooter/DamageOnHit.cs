using UnityEngine;

public class DamageonHit : MonoBehaviour
{
    public float DamageAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a Health component
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null) // Corrected the variable name to 'health'
        {
            // Apply damage to the health component
            health.TakeDamage(DamageAmount); // Use the correct type and method
        }

        Destroy(gameObject);
    }
}
