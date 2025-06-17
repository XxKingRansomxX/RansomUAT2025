using UnityEngine;
using UnityEngine.UI;

public class PlayerPawn : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float normalSpeed;
    public float turboSpeed;

    public float rotationSpeed;
    public float rotationSpeedTurbo;

    public float worldTeleportSpeed;

    private Transform tf;

    public Shooter shooter; // Reference to the Shooter class for shooting functionality

    

    public int lives = 3; // Number of lives
    public int health = 100; // Health per life
    public int maxHealth = 100; // Max health per life

    [SerializeField] private Image healthBarImage; // Assign your UI Image (set to Filled) in the Inspector


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = transform;
        shooter = GetComponent<Shooter>();
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        TeleportIfOutOfBounds();
    }

    // Call this method when the player collides with a meteor
    public void TakeDamage(int amount = 10)
    {
        health -= amount;
        if (health <= 0)
        {
            lives--;
            if (lives > 0)
            {
                health = maxHealth; // Reset health for next life
            }
            else
            {
                health = 0;
            }
        }
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthBarImage != null)
            healthBarImage.fillAmount = (float)health / maxHealth;
    }

    private void TeleportIfOutOfBounds()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        Vector2 viewportPos = cam.WorldToViewportPoint(transform.position);
        Vector2 newPos = transform.position;
        bool teleported = false;

        // Teleport on X axis
        if (viewportPos.x < 0f)
        {
            newPos = cam.ViewportToWorldPoint(new Vector2(1f, viewportPos.y));
            teleported = true;
        }
        else if (viewportPos.x > 1f)
        {
            newPos = cam.ViewportToWorldPoint(new Vector2(0f, viewportPos.y));
            teleported = true;
        }

        // Teleport on Y axis
        if (viewportPos.y < 0f)
        {
            newPos = cam.ViewportToWorldPoint(new Vector2(viewportPos.x, 1f));
            teleported = true;
        }
        else if (viewportPos.y > 1f)
        {
            newPos = cam.ViewportToWorldPoint(new Vector2(viewportPos.x, 0f));
            teleported = true;
        }

        if (teleported)
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }

    public void TeleportToPosition()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        tf.position = new Vector3(randomPosition.x, randomPosition.y, tf.position.z);
    }

    // Local movement methods
    public void MoveForward()
    {
        Vector3 positionOffset = tf.up * normalSpeed * Time.deltaTime;
        tf.position = tf.position + positionOffset;
    }

    public void MoveBackward()
    {
        Vector3 positionOffset = -tf.up * normalSpeed * Time.deltaTime;
        tf.position = tf.position + positionOffset;
    }

    public void RotateClockwise()
    {
        tf.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }

    public void RotateCounterClockwise()
    {
        tf.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    // Turbo movement methods
    public void MoveForwardTurbo()
    {
        Vector3 positionOffset = tf.up * turboSpeed * Time.deltaTime;
        tf.position = tf.position + positionOffset;
    }

    public void MoveBackwardTurbo()
    {
        Vector3 positionOffset = -tf.up * turboSpeed * Time.deltaTime;
        tf.position = tf.position + positionOffset;
    }

    public void RotateClockwiseTurbo()
    {
        tf.Rotate(0, 0, -rotationSpeedTurbo * Time.deltaTime);
    }

    public void RotateCounterClockwiseTurbo()
    {
        tf.Rotate(0, 0, rotationSpeedTurbo * Time.deltaTime);
    }

    // World movement methods
    public void MoveWorldUp()
    {
        Vector3 positionOffset = Vector3.up * worldTeleportSpeed;
        tf.position = tf.position + positionOffset;
    }

    public void MoveWorldDown()
    {
        Vector3 positionOffset = Vector3.down * worldTeleportSpeed;
        tf.position = tf.position + positionOffset;
    }

    public void MoveWorldLeft()
    {
        Vector3 positionOffset = Vector3.left * worldTeleportSpeed;
        tf.position = tf.position + positionOffset;
    }

    public void MoveWorldRight()
    {
        Vector3 positionOffset = Vector3.right * worldTeleportSpeed;
        tf.position = tf.position + positionOffset;
    }

    public void Shoot()
    {
        if (shooter != null)
        {
            shooter.Shoot();
        }
    }
}
