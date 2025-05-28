using UnityEngine;

public class PlayerSpace : MonoBehaviour
{
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    private Transform tf;

    void Start()
    {
        tf = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 pos = tf.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        tf.position = pos;
    }
}