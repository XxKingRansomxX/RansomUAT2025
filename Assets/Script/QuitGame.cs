using UnityEngine;

public class QuitGame : MonoBehaviour
{

    public KeyCode quitKey = KeyCode.Escape; // Default key to quit the game
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
    }
}
