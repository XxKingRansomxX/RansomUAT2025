using UnityEngine;

public class DeathTarget : Death
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.RegisterTarget(); // Register this target with the GameManager
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Die()
    {
        GameManager.instance.UnregisterTarget(); // Unregister this target from the GameManager

        Destroy(gameObject); // Destroy the target GameObject
    }
}
