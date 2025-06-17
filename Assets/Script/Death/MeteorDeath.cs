using UnityEngine;

public class MeteorDeath : Death
{
    [SerializeField] private GameObject smallMeteorPrefab; // Assign your small meteor prefab in the Inspector
    [SerializeField] private int smallMeteorCount = 4;     // Number of small meteors to spawn
    [SerializeField] private float explosionRadius = 1.5f; // How far from the center to spawn the small meteors
    [SerializeField] private GameObject explosionEffectPrefab; // Optional: assign an explosion effect prefab

    // Called when the meteor should be destroyed (e.g., by bullet)
    public override void Die()
    {
        // Award points and unregister target
        if (GameManager.instance != null)
        {
            GameManager.instance.AwardPoints(100); // or any value you want
            GameManager.instance.UnregisterTarget();
        }

        // Spawn small meteors in a circle
        if (smallMeteorPrefab != null)
        {
            for (int i = 0; i < smallMeteorCount; i++)
            {
                float angle = (360f / smallMeteorCount) * i * Mathf.Deg2Rad;
                Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                Vector2 pos = (Vector2)transform.position + dir * explosionRadius;
                SmallMeteorPiece.CreateSmallMeteorPiece(smallMeteorPrefab, pos, dir);
            }
        }

        // Optional: spawn explosion effect
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Destroy the original meteor
        Destroy(gameObject);
    }
}

