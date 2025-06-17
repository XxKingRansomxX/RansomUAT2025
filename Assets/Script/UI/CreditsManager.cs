using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public GameObject mainMenuPanel;

    // Called before the first frame update
    void Start()
    {
        // Initialize credits UI or logic here if needed
    }

    // Called once per frame
    void Update()
    {
        // Add per-frame logic for credits here if needed
    }

    public void OnBackToMainMenu()
    { 
        SceneManager.LoadScene("MainMenu");
    }
}