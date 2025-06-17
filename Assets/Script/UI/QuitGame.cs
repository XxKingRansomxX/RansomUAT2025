using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public KeyCode quitKey = KeyCode.Escape; // Default key to quit the game
    public KeyCode openMenuKey = KeyCode.M;  // Key to open the main menu (set in Inspector)
    public GameObject mainMenuPanel;         // Assign your main menu panel in the Inspector
    public string sceneToLoad = "MainMenu"; // Set this in the Inspector to your scene's name
    public KeyCode loadSceneKey = KeyCode.N; // Set this to the key you want

    public string mainMenuScene = "MainMenu";      // Set to your main menu scene name
    public string settingsScene = "Settings";      // Set to your settings scene name
    public string creditsScene = "Credits";        // Set to your credits scene name

    public KeyCode mainMenuKey = KeyCode.F1;       // Key to load main menu
    public KeyCode settingsKey = KeyCode.F2;       // Key to load settings
    public KeyCode creditsKey = KeyCode.F3;        // Key to load credits

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(quitKey))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(openMenuKey) && mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true); // Show the main menu
        }

        if (Input.GetKeyDown(loadSceneKey))
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        if (Input.GetKeyDown(mainMenuKey))
            SceneManager.LoadScene(mainMenuScene);

        if (Input.GetKeyDown(settingsKey))
            SceneManager.LoadScene(settingsScene);

        if (Input.GetKeyDown(creditsKey))
            SceneManager.LoadScene(creditsScene);
    }
}
