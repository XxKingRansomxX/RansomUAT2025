using UnityEngine;

public class DeathTarget : Death
{
   

    public int pointsToAward; // Points to award when the target is destroyed 

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

        GameManager.instance.AwardPoints(pointsToAward); // Award points to the player

        Destroy(gameObject); // Destroy the target GameObject
    }
}
