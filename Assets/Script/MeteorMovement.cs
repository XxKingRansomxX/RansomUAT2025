using System.Xml.Serialization;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;

    public MeteorSpawner spawner;
    public bool isMain = false; // Optional: set by spawner, not used for logic

    private Vector2 moveDirection = Vector2.zero;

    /// <summary>
    /// Sets the movement direction for the meteor. Should be a normalized vector.
    /// </summary>
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    void Start()
    {
        // If no direction was set externally, pick a random direction
        if (moveDirection == Vector2.zero)
        {
            float angle = Random.Range(0f, 360f);
            float rad = angle * Mathf.Deg2Rad;
            moveDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
        }
    }

    void Update()
    {
        // Move the meteor in the chosen direction
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);

        // Teleport to opposite side if out of screen bounds
        TeleportIfOutOfBounds();
    }

    private void TeleportIfOutOfBounds()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);

        bool teleported = false;
        Vector3 newPos = transform.position;

        if (viewportPos.x < 0f) { newPos = cam.ViewportToWorldPoint(new Vector3(1f, viewportPos.y, viewportPos.z)); teleported = true; }
        else if (viewportPos.x > 1f) { newPos = cam.ViewportToWorldPoint(new Vector3(0f, viewportPos.y, viewportPos.z)); teleported = true; }

        if (viewportPos.y < 0f) { newPos = cam.ViewportToWorldPoint(new Vector3(viewportPos.x, 1f, viewportPos.z)); teleported = true; }
        else if (viewportPos.y > 1f) { newPos = cam.ViewportToWorldPoint(new Vector3(viewportPos.x, 0f, viewportPos.z)); teleported = true; }

        if (teleported)
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only destroy if hit by a bullet
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            Destroy(gameObject);
        }
        // Optionally, handle other collision logic here (e.g., bounce, ignore, etc.)
    }
}