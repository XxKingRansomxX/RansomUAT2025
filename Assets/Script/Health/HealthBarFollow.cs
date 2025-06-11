using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HealthBarFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Assign the asteroid's transform in the Inspector
    [SerializeField] private Vector3 offset = new Vector3(0, -1f, 0);
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
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.rotation = Quaternion.identity; // Keep upright
        }
    }
}
