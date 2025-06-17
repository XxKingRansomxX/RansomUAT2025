using UnityEngine;

public class GameOverStageComplete : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject stageCompletePanel;

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        Time.timeScale = 60f; // Optional: pause the game
    }

    public void ShowStageComplete()
    {
        if (stageCompletePanel != null)
            stageCompletePanel.SetActive(true);
        Time.timeScale = 60f; // Optional: pause the game
    }
    


// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
