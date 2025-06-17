using UnityEngine;
using System.Collections.Generic;

public class UFOSpawner : MonoBehaviour
{
    public GameObject ufoPrefab; // Assign your UFO prefab in the Inspector
    public GameObject meteorPrefab; // Assign your Meteor prefab in the Inspector
    public float offScreenBuffer = 2f; // How far off-screen to spawn UFOs
    public int maxMeteors; // Maximum number of meteors allowed
    public int meteorsPerSpawn; // Number of meteors to spawn per call

   

    void Start()
    {
        SpawnThreeUFOs();
    }

  

    void SpawnThreeUFOs()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnUFOOffScreen();
        }
    }

    void SpawnUFOOffScreen()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        // Pick a random edge: 0=left, 1=right, 2=bottom, 3=top
        int edge = Random.Range(0, 4);
        Vector2 spawnPos = Vector2.zero;

        float zDist = Mathf.Abs(cam.transform.position.z);
        Vector3 screenMin = cam.ViewportToWorldPoint(new Vector3(0, 0, zDist));
        Vector3 screenMax = cam.ViewportToWorldPoint(new Vector3(1, 1, zDist));

        switch (edge)
        {
            case 0: // Left
                spawnPos.x = screenMin.x - offScreenBuffer;
                spawnPos.y = Random.Range(screenMin.y, screenMax.y);
                break;
            case 1: // Right
                spawnPos.x = screenMax.x + offScreenBuffer;
                spawnPos.y = Random.Range(screenMin.y, screenMax.y);
                break;
            case 2: // Bottom
                spawnPos.x = Random.Range(screenMin.x, screenMax.x);
                spawnPos.y = screenMin.y - offScreenBuffer;
                break;
            case 3: // Top
                spawnPos.x = Random.Range(screenMin.x, screenMax.x);
                spawnPos.y = screenMax.y + offScreenBuffer;
                break;
        }

       
    }

    
    
}