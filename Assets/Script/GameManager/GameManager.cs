using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text scoreText;

    public TMP_Text remainingText;

    public int targetCount = 0; // Number of targets in the game

    public int score = 0; // Player's score

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

        if (remainingText != null)
        { 
            remainingText.text = "Remaining: " + targetCount; // Update the remaining targets text
        }
    }

    public void UnregisterTarget()
    {
        targetCount--;


        if (remainingText != null)
        {
            remainingText.text = "Remaining: " + targetCount; // Update the remaining targets text
        }
    }
    public void AwardPoints(int pointsAwarded) 
    { 
        score += pointsAwarded; // Add the awarded points to the player's score

        if (scoreText != null) 
        { 
            scoreText.text = "Score: " + score; // Update the score text
        }
    }
    public void ResetGame()
    {
        score = 0;
        targetCount = 0;

        if (scoreText != null)
            scoreText.text = "Score: 0";

        if (remainingText != null)
            remainingText.text = "Remaining: 0";
    }
}