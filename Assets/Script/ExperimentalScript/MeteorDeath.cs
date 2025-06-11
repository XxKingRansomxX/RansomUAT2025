using UnityEngine;

public class MeteorDeath : Death
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Optional: Per-frame logic if needed
    }

    void OnDestroy()
    {

    }

    // Call this method to make the meteor explode into smaller pieces and disappear
    public void Explode()
    {
        Destroy(gameObject); // Just destroy the meteor, no splitting
    }

    // Implementation of the abstract method from the Death class
    public override void Die()
    {
        Explode(); // Use the Explode method to handle the death logic
    }
}
