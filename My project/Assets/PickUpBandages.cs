using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBandages : MonoBehaviour
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
                PI.AddBandage(1);

                // Log to confirm the actions
                Debug.Log("Bandages picked up and attached to player");
            }
        }
    }
}
