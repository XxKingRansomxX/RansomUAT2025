using UnityEngine;

public class DeathMoveToOrigin : Death
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        // Move the GameObject this script is attached to to the origin (0, 0, 0)
        Debug.Log("DeathMoveToOrigin: Die() called, moving GameObject to origin.");
        gameObject.transform.position = new Vector3(0.0f,0.0f,0.0f);
    }
}
