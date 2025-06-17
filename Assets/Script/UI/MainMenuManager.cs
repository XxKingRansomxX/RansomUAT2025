using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel; // Assign your main menu panel in the Inspector
    public GameObject settingsPanel; // Assign your settings panel in the Inspector
    public GameObject creditsPanel;  // Assign your credits panel in the Inspector

    public KeyCode openMainMenuKey = KeyCode.Escape; 

    // Call this from your Play/New Game button's OnClick event in the Inspector
    public void OnNewGame()
    {
        SceneManager.LoadScene("GameScene"); // Use your game scene's exact name
    }

    // Call this from your Settings button's OnClick event in the Inspector
    public void OnSettings()
    {
        SceneManager.LoadScene("SettingsScene"); // Use your settings scene's exact name
    }

    // Call this from your Credits button's OnClick event in the Inspector
    public void OnCredits()
    {
        SceneManager.LoadScene("CreditsScene"); // Use your credits scene's exact name
    }

    // Call this from your Back button's OnClick event in the Inspector (in Settings or Credits)
    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
