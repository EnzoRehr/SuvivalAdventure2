using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupNote : MonoBehaviour
{
    public GameObject Letter;
    private bool isLetterDisplayed = false; // Track the display state of the letter

    private void OnTrigger(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Log when the player is detected
            Debug.Log("Player detected");

            if (Input.GetKeyDown(KeyCode.F))
            {
                // Log when the F key is pressed
                Debug.Log("F key pressed");
                this.gameObject.SetActive(false);
                // Toggle the letter's active state
                isLetterDisplayed = !isLetterDisplayed;
                Letter.SetActive(isLetterDisplayed);

                // Pause or unpause the game based on the letter's state
                Time.timeScale = 0.0f;

                // Log the current state
                if (isLetterDisplayed)
                {
                    Debug.Log("Letter displayed and game paused");
                    
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Time.timeScale = 1.0f;
                        isLetterDisplayed = !isLetterDisplayed;
                        Letter.SetActive(isLetterDisplayed);
                        this.gameObject.SetActive(true);
                    }

                }               
            }
        }
    }
}
