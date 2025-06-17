using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public float speed;
    public float spinSpeed; // Degrees per second, adjustable in Inspector
    public bool trackPlayer = true; // Show as a checkbox in Inspector
    private Transform player;

    void Start()
    {
        // Find the PlayerPawn in the scene (assumes PlayerPawn has the "Player" tag)
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        // Only track and move towards the player if enabled
        if (trackPlayer && player != null)
        {
            Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;
            transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
        }

        // Spin the UFO in 2D (around Z axis)
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);

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
}

