using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    public bool isMain = false; // Optional: set by spawner, not used for logic

    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody2D rb;

    /// Sets the movement direction for the meteor. Should be a normalized vector.
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
        if (rb != null)
            rb.linearVelocity = moveDirection * speed;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();

        rb.gravityScale = 0; // Keep if you want no gravity
        rb.freezeRotation = false; // Allow rotation for force response

        // If direction wasn't set by spawner, pick a random one
        if (moveDirection == Vector2.zero)
        {
            float angle = Random.Range(0f, 360f);
            float rad = angle * Mathf.Deg2Rad;
            moveDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
        }
        rb.linearVelocity = moveDirection * speed;
    }

    void Update()
    {
        // Keep moving in the set direction
        rb.linearVelocity = moveDirection * speed;
        TeleportIfOutOfBounds();
    }

    // Teleport to the opposite side of the screen if out of bounds
    private void TeleportIfOutOfBounds()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        Vector2 viewportPos = cam.WorldToViewportPoint(transform.position);
        Vector2 newPos = transform.position;
        bool teleported = false;

        if (viewportPos.x < 0f) { newPos = cam.ViewportToWorldPoint(new Vector2(1f, viewportPos.y)); teleported = true; }
        else if (viewportPos.x > 1f) { newPos = cam.ViewportToWorldPoint(new Vector2(0f, viewportPos.y)); teleported = true; }

        if (viewportPos.y < 0f) { newPos = cam.ViewportToWorldPoint(new Vector2(viewportPos.x, 1f)); teleported = true; }
        else if (viewportPos.y > 1f) { newPos = cam.ViewportToWorldPoint(new Vector2(viewportPos.x, 0f)); teleported = true; }

        if (teleported)
            transform.position = new Vector2(newPos.x, newPos.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy if hit by a bullet
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            TakeDamage(bullet.damage); // Fix: Add the TakeDamage method implementation below
            Destroy(bullet.gameObject);
            return;
        }

        // Destroy if hit by the player pawn
        var playerPawn = collision.gameObject.GetComponent<PlayerPawn>();
        if (playerPawn != null)
        {
            var death = GetComponent<MeteorDeath>();
            if (death != null)
                death.Die();
            else
                Destroy(gameObject);
        }
    }

    // Fix: Add the missing TakeDamage method
    private void TakeDamage(float damage)
    {
        // Example implementation: Destroy the meteor when it takes damage
        Destroy(gameObject);
    }
}