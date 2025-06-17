    using UnityEngine;

public class RandomPositionMover : MonoBehaviour
{

    // Declare our variables
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Transform tf;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = transform; 
        //tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Vector3 RandomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);

            tf.position = RandomPosition;
        }
    }
       
}
