using UnityEngine;

public class MeteorDeath : Death
{
    [SerializeField] private GameObject smallMeteorPrefab; // Assign your small meteor prefab in the Inspector
    [SerializeField] private int smallMeteorCount = 4;     // Number of small meteors to spawn
    [SerializeField] private float explosionRadius = 1.5f; // How far from the center to spawn the small meteors

    // Implementation of the abstract method from the Death class
    public override void Die()
    {
        Explode();
    }

    // Call this method to make the meteor explode into smaller pieces and disappear
    public void Explode()
    {
        if (smallMeteorPrefab != null)
        {
            for (int i = 0; i < smallMeteorCount; i++)
            {
                float angle = (360f / smallMeteorCount) * i * Mathf.Deg2Rad;
                Vector2 spawnDir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                Vector2 spawnPos = (Vector2)transform.position + spawnDir * explosionRadius * Random.Range(0.7f, 1.2f);

                GameObject smallMeteor = Instantiate(smallMeteorPrefab, spawnPos, Quaternion.identity);
                smallMeteor.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Adjust as needed

                var piece = smallMeteor.GetComponent<SmallMeteorPiece>();
                if (piece != null)
                {
                    piece.SetDirection(spawnDir); // This line is essential for movement!
                }
                Destroy(smallMeteor, 1f); // Disappear after 1 second
            }
        }
        Destroy(gameObject); // Destroy the original meteor
    }
}

