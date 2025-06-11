using UnityEngine;

public class DeathDestroy : Death
{
    [SerializeField] private int pointsToAward = 100; // Set this in the Inspector
    [SerializeField] private bool registerWithGameManager = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.instance != null && registerWithGameManager)
            GameManager.instance.RegisterTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Die() // Implement the abstract method from the Death class
    {
        if (GameManager.instance != null && registerWithGameManager)
        {
            GameManager.instance.UnregisterTarget();
            GameManager.instance.AwardPoints(pointsToAward); // This updates the score in GameManager
        }
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
