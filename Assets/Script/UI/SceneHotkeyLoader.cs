using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHotkeyLoader : MonoBehaviour
{
    public string mainMenuScene = "MainMenu";
    public string settingsScene = "Settings";
    public string creditsScene = "Credits";

    public KeyCode mainMenuKey = KeyCode.F1;
    public KeyCode settingsKey = KeyCode.F2;
    public KeyCode creditsKey = KeyCode.F3;

    void Update()
    {
        if (Input.GetKeyDown(mainMenuKey))
            SceneManager.LoadScene(mainMenuScene);

        if (Input.GetKeyDown(settingsKey))
            SceneManager.LoadScene(settingsScene);

        if (Input.GetKeyDown(creditsKey))
            SceneManager.LoadScene(creditsScene);
    }
}