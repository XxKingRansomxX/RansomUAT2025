using UnityEngine;

public class SmallMeteorPiece : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Vector2 moveDirection = Vector2.zero;

    public void Initialize(Vector2 direction, float lifetime)
    {
        moveDirection = direction.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position = (Vector2)transform.position + moveDirection * speed * Time.deltaTime;
    }

    public static void CreateSmallMeteorPiece(GameObject smallMeteorPrefab, Vector2 pos, Vector2 dir)
    {
        var pieceObj = Instantiate(smallMeteorPrefab, pos, Quaternion.identity);
        pieceObj.transform.localScale = new Vector2(0.5f, 0.5f);
        var piece = pieceObj.GetComponent<SmallMeteorPiece>();
        if (piece != null)
            piece.Initialize(dir, 1f);
    }
}