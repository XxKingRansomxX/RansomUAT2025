using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float damage = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Do not damage the player pawn
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Optionally destroy the bullet, or remove this line if you want bullets to pass through
            return;
        }

        // Deal damage to any other object with Health
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
