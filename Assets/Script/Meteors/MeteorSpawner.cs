using UnityEngine;
using System.Collections.Generic;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private int meteorsPerSpawn; // Set this in the Inspector

    private List<GameObject> activeMeteors = new List<GameObject>();

    void Start()
    {
        SpawnMeteors();
    }

    void Update()
    {
        // Remove destroyed meteors from the list
        activeMeteors.RemoveAll(meteor => meteor == null);

        // If all meteors are destroyed, spawn new ones
        if (activeMeteors.Count == 0)
        {
            SpawnMeteors();
        }
    }

    private void SpawnMeteors()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        for (int i = 0; i < meteorsPerSpawn; i++)
        {
            // Spawn at a random edge
            int edge = Random.Range(0, 4);
            float zDist = Mathf.Abs(cam.transform.position.z);
            Vector3 screenMin = cam.ViewportToWorldPoint(new Vector3(0, 0, zDist));
            Vector3 screenMax = cam.ViewportToWorldPoint(new Vector3(1, 1, zDist));
            Vector2 spawnPos = Vector2.zero;
            Vector2 direction = Vector2.zero;

            switch (edge)
            {
                case 0: // Left
                    spawnPos.x = screenMin.x - 1f;
                    spawnPos.y = Random.Range(screenMin.y, screenMax.y);
                    direction = Vector2.right;
                    break;
                case 1: // Right
                    spawnPos.x = screenMax.x + 1f;
                    spawnPos.y = Random.Range(screenMin.y, screenMax.y);
                    direction = Vector2.left;
                    break;
                case 2: // Bottom
                    spawnPos.x = Random.Range(screenMin.x, screenMax.x);
                    spawnPos.y = screenMin.y - 1f;
                    direction = Vector2.up;
                    break;
                case 3: // Top
                    spawnPos.x = Random.Range(screenMin.x, screenMax.x);
                    spawnPos.y = screenMax.y + 1f;
                    direction = Vector2.down;
                    break;
            }

            float angleOffset = Random.Range(-30f, 30f);
            direction = Quaternion.Euler(0, 0, angleOffset) * direction;

            GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
            activeMeteors.Add(meteor);

            var movement = meteor.GetComponent<MeteorMovement>();
            if (movement != null)
            {
                movement.SetDirection(direction.normalized);
            }
        }
    }
}
