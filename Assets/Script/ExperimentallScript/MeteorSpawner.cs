using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float spawnRadius = 12f; // Distance from screen center to spawn
    [SerializeField] private int meteorsPerSpawn = 1;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating(nameof(SpawnMeteor), 0f, spawnInterval);
    }

    void SpawnMeteor()
    {
        for (int i = 0; i < meteorsPerSpawn; i++)
        {
            // Pick a random angle around the screen
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector2 spawnDir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 spawnPos = (Vector2)mainCamera.transform.position + spawnDir * spawnRadius;

            GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
            // Optionally, point the meteor toward the screen center
            MeteorMovement movement = meteor.GetComponent<MeteorMovement>();
            if (movement != null)
            {
                movement.SetDirection((-spawnDir).normalized);
            }
        }
    }
}