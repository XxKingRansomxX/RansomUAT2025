using UnityEngine;

public class DeathDestroy : Death
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
        // Destroy the GameObject this script is attached to
      Debug.Log("DeathDestroy: Die() called, destroying GameObject.");
        Destroy(gameObject);
    }
}
