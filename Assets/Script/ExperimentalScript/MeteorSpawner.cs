using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private int meteorsPerSpawn = 1;
    [SerializeField] private Transform playerTransform; // Assign your player here in the Inspector
    [SerializeField] private float playerSpaceRadius = 5f; // Set this to match your player's play area radius
    [SerializeField] private GameObject mainMeteorPrefab; // Assign your main meteor prefab here

    private GameObject currentMainMeteor;

    void Start()
    {
        // Try to auto-assign player if not set in Inspector
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerTransform = player.transform;
        }
        InvokeRepeating(nameof(SpawnMeteor), 0f, spawnInterval);

        // Spawn the main meteor at start
        SpawnMainMeteor();
    }

    void SpawnMeteor()
    {
        if (playerTransform == null) return;

        Vector2 playerPos = playerTransform.position;

        for (int i = 0; i < meteorsPerSpawn; i++)
        {
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector2 spawnDir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 spawnPos = playerPos + spawnDir * playerSpaceRadius;

            GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
            MeteorMovement movement = meteor.GetComponent<MeteorMovement>();
            if (movement != null)
            {
                // Move toward the player
                movement.SetDirection((playerPos - spawnPos).normalized);
                movement.spawner = this;
            }
        }
    }

    public void SpawnMainMeteor()
    {
        if (playerTransform == null || mainMeteorPrefab == null) return;

        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 spawnDir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Vector2 spawnPos = (Vector2)playerTransform.position + spawnDir * playerSpaceRadius;

        currentMainMeteor = Instantiate(mainMeteorPrefab, spawnPos, Quaternion.identity);
        MeteorMovement movement = currentMainMeteor.GetComponent<MeteorMovement>();
        if (movement != null)
        {
            movement.SetDirection((playerTransform.position - (Vector3)spawnPos).normalized);
            movement.spawner = this;
            movement.isMain = true; // Optional, for debugging/identification only
        }

        var handler = currentMainMeteor.GetComponent<CurrentMainMeteorHandler>();
        if (handler != null)
        {
            Vector2 direction = (playerTransform.position - (Vector3)spawnPos).normalized;
            handler.Initialize(this, direction, /*optional*/ 0.1f);
        }
    }

    // Called by MeteorMovement when any meteor leaves the screen
    public void OnMeteorLeftScreen(MeteorMovement meteor)
    {
        // Only respawn if this was the main meteor
        if (currentMainMeteor != null && meteor.gameObject == currentMainMeteor)
        {
            SpawnMainMeteor();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}