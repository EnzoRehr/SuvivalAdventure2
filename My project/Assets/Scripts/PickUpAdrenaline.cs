using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAdrenaline : MonoBehaviour
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
                PI.AddAdrenalineInjection(1);

                // Log to confirm the actions
                Debug.Log("Adrenaline picked up and attached to player");
            }
        }
    }
}
