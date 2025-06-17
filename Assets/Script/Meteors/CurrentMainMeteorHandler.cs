using UnityEngine;

public class CurrentMainMeteorHandler : MonoBehaviour
{
    private MeteorSpawner spawner;
    private float speed = 0.1f;
    private Vector2 moveDirection;

    public void Initialize(MeteorSpawner meteorSpawner, Vector2 direction, float meteorSpeed = 0.1f)
    {
        spawner = meteorSpawner;
        moveDirection = direction.normalized;
        speed = meteorSpeed;
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);

        if (!IsVisibleFrom(Camera.main))
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisibleFrom(Camera camera)
    {
        if (camera == null) return false;

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds);
    }

    void OnDestroy()
    {
        // Only respawn if this is not being destroyed because the game is quitting
        if (!Application.isPlaying) return;

        // Instantiate a new meteor at a desired position and direction
        Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f); // Example spawn logic
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; // Example direction logic
        GameObject newMeteor = Instantiate(gameObject, spawnPos, Quaternion.identity);

        var handler = newMeteor.GetComponent<CurrentMainMeteorHandler>();
        if (handler != null)
        {
            handler.Initialize(null, direction, speed); // Pass null or the appropriate spawner reference
        }
    }
}