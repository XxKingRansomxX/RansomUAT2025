using UnityEngine;

public class DeathDestroy : Death
{
    [SerializeField] private int pointsToAward = 100; // Set this in the Inspector
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Die() // Implement the abstract method from the Death class
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.UnregisterTarget();
            GameManager.instance.AwardPoints(pointsToAward); // This updates the score in GameManager
        }
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
