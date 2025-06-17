using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Add this for scene loading

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text scoreText;
    public TMP_Text remainingText;
    public TMP_Text healthText;

    public int targetCount = 0; // Number of targets in the game
    public int score = 0; // Player's score

    public GameObject mainMenuPanel; // Reference to the main menu panel
    public KeyCode openMainMenuKey = KeyCode.Escape; // Key to toggle the main menu

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        { 
            Destroy(gameObject); 
        }      
    }
    void Start()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        if (remainingText != null)
            remainingText.text = "Remaining: " + targetCount;
        if (healthText != null)
            healthText.text = "Health: 100";
    }

    void Update()
    {
        
    }

    public void UnregisterTarget()
    {
        targetCount--;
        if (remainingText != null)
        {
            remainingText.text = "Remaining: " + targetCount;
        }
    }

    public void RegisterTarget()
    {
        targetCount++;
        if (remainingText != null)
        {
            remainingText.text = "Remaining: " + targetCount;
        }
    }

    public void AwardPoints(int pointsAwarded) 
    { 
        score += pointsAwarded;
        if (scoreText != null) 
        { 
            scoreText.text = "Score: " + score;
        }
    }
    
    public void UpdateHealth(int health)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }

    // Add this method to load the main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your main menu scene name
    }
}