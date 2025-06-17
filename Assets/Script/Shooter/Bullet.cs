using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float damage = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy bullet if it hits the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            return;
        }

        // Destroy meteor using MeteorDeath if present
        var meteor = collision.gameObject.GetComponent<MeteorMovement>();
        if (meteor != null)
        {
            var death = collision.gameObject.GetComponent<MeteorDeath>();
            if (death != null)
                death.Die();
            else
                Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }

        // Deal damage to any object with Health (optional)
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
