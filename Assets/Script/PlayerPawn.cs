using UnityEngine;

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

    [SerializeField] private GameOverStageComplete gameOverStageComplete;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = transform;

        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TeleportToPosition()
    {

        Vector3 RandomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);

        tf.position = RandomPosition;
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
