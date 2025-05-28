using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    // Declare our variables public SpriteRenderer theRenderer; 
    // variable for our sprite renderer 
    private SpriteRenderer theRenderer; // variable for our sprite renderer //variable for our color
    public Color spriteColor; // variable for our color // Use this for initialization

    // Use for initialization
    void Start()
    {
        // Set the color of our sprite to the color we set in the inspector
        // Get the SpriteRenderer component attached to this GameObject
        theRenderer = GetComponent<SpriteRenderer>();

        // Change the color from our color picker so that the alpha is 1
        spriteColor.a = 1.0f;

        // As long as theRenderer has been set
        if (theRenderer != null)
        {
            // Change the "color" value of the SpriteRenderer component to our new color
            theRenderer.color = spriteColor;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
