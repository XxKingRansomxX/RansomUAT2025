using UnityEngine;

public class MeteorDeath : MonoBehaviour
{
    [SerializeField] private GameObject smallerMeteorPrefab;
    [SerializeField] private int pieces = 3;
    [SerializeField] private float spawnRadius = 0.5f;
    [SerializeField] private GameOverStageComplete gameOverStageComplete;

    // Removed invalid code causing errors
    // gameOverStageComplete.ShowStageComplete();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pieces = Random.Range(2, 6); // Each meteor splits into 2–5 pieces
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: Per-frame logic if needed
    }

    // Call this method to make the meteor explode into smaller pieces and disappear
    public void Explode()
    {
        for (int i = 0; i < pieces; i++)
        {
            // Calculate a random direction for each piece
            float angle = (360f / pieces) * i + Random.Range(-10f, 10f);
            float rad = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            // Spawn the smaller meteor
            GameObject piece = Instantiate(
                smallerMeteorPrefab,
                transform.position + (Vector3)(direction * spawnRadius),
                Quaternion.identity
            );

            // Optionally, add force to the pieces if they have Rigidbody2D
            Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(direction * 3f, ForceMode2D.Impulse);
            }

        }



        // Show Stage Complete if this is the last meteor
        if (FindObjectsOfType<MeteorDeath>().Length == 1 && gameOverStageComplete != null)
        {
            gameOverStageComplete.ShowStageComplete();
        }

        Destroy(gameObject);
    }
}    
