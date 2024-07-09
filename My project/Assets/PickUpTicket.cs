using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTicket : MonoBehaviour
{
    public PlayerInventory PI;
    private void OnTriggerStay(Collider other)
    {


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
                PI.AddTicket(1);

                // Log to confirm the actions
                Debug.Log("Ticket picked up and attached to player");
            }
        }
    }
}