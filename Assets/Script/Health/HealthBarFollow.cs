using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Assign the meteor or UFO's transform in the Inspector
    [SerializeField] private Vector3 offset = new Vector3(0, -1f, 0);

    void LateUpdate()
    {
        if (target != null)
        {
            // Set position to always be at the bottom of the target (meteor or UFO)
            transform.position = target.position + offset;
            // Keep the health bar upright (no rotation)
            transform.rotation = Quaternion.identity;
        }
    }

    void OnEnable()
    {
        // Ensure the health bar starts upright
        transform.rotation = Quaternion.identity;
    }
}
