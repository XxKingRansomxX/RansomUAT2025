using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    void LateUpdate()
    {
        // Always keep the health bar upright (no rotation)
        transform.rotation = Quaternion.identity;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
