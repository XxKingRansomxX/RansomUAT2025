using UnityEngine;

public class UFODebris : Death
{
    [SerializeField] private GameObject smallDebrisPiecePrefab; // Assign your small debrisPiece prefab in the Inspector
    [SerializeField] private int smallDebrisCount;     // Number of small debris pieces to spawn
    [SerializeField] private float explosionRadius = 1.5f; // How far from the center to spawn the debris
    [SerializeField] private GameObject explosionEffectPrefab; // Optional: assign an explosion effect prefab

    public override void Die()
    {
        // Award points and unregister target
        

        // Spawn small debris in a circle
        if (smallDebrisPiecePrefab != null)
        {
            for (int i = 0; i < smallDebrisCount; i++)
            {
                float angle = (360f / smallDebrisCount) * i * Mathf.Deg2Rad;
                Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                Vector2 pos = (Vector2)transform.position + dir * explosionRadius;

                GameObject debris = Instantiate(smallDebrisPiecePrefab, pos, Quaternion.identity);
                Rigidbody2D rb = debris.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = dir * 5f;
                }
            }
        }

        // Optional: spawn explosion effect
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Destroy the original UFO
        Destroy(gameObject);
    }
}