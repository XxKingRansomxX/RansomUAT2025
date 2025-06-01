using System.Xml.Serialization;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private Vector2 moveDirection;

    // Removed the duplicate method definition to resolve CS0111
    internal void SetDirection(Vector2 normalized)
    {
        moveDirection = normalized.normalized;
    }

    void Start()
    {
        // Pick a random direction (normalized vector)
        float angle = Random.Range(0f, 360f);
        float rad = angle * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
    }

    void Update()
    {
        // Move the meteor in the chosen direction
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
        // Destroy meteor if it leaves the screen
        if (!IsVisibleFrom(Camera.main))
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisibleFrom(Camera cam)
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);
        return viewportPos.x > 0 && viewportPos.x < 1 && viewportPos.y > 0 && viewportPos.y < 1;
    }
}
   