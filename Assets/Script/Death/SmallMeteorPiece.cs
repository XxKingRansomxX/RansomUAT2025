using UnityEngine;

public class SmallMeteorPiece : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Vector2 moveDirection = Vector2.zero;

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
    }

    public static void SpawnSmallMeteor(GameObject smallMeteorPrefab, Vector3 spawnPos, Vector2 spawnDir)
    {
        GameObject smallMeteor = Instantiate(smallMeteorPrefab, spawnPos, Quaternion.identity);
        smallMeteor.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Adjust as needed

        var piece = smallMeteor.GetComponent<SmallMeteorPiece>();
        if (piece != null)
        {
            piece.SetDirection(spawnDir); // This makes the small meteor move!
        }
    }
}