using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpShovel : MonoBehaviour
{
    public GameObject ShovelOnPlayer;

    void Start()
    {
        ShovelOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        // Log when the trigger is entered
        Debug.Log("Trigger stay detected");

        if (other.gameObject.tag == "Player")
        {
            // Log when the player is detected
            Debug.Log("Player detected");

            if (Input.GetKey(KeyCode.F))
            {
                // Log when the F key is pressed
                Debug.Log("F key pressed");

                // Deactivate the current shovel
                this.gameObject.SetActive(false);
                // Activate the shovel on the player
                ShovelOnPlayer.SetActive(true);

                // Log to confirm the actions
                Debug.Log("Shovel picked up and attached to player");
            }
        }
    }
}