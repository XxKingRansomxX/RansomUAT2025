using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnNewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void OnSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void OnQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
