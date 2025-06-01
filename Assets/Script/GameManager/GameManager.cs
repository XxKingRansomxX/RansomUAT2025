using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int targetCount = 0; // Number of targets in the game   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject); // Prevents the GameManager from being destroyed when loading a new scene
        }
        else 
        { 
            Destroy(gameObject); 
        }      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RegisterTarget()
    {
        targetCount++;
    }

    public void UnregisterTarget()
    {
        targetCount--;
        if (targetCount < 0)
        {
            targetCount = 0; // Ensure target count does not go negative
        }
    }
}
