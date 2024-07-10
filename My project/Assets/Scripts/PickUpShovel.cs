using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpShovel : MonoBehaviour
{
    public GameObject ShovelOnPlayer;
    public TextMeshProUGUI display;

    void Start()
    {
        ShovelOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
       

        if (other.gameObject.tag == "Player")
        {
            // Log when the player is detected
            Debug.Log("Player detected");
            display.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                // Log when the F key is pressed
                Debug.Log("F key pressed");

                // Deactivate the current shovel
                this.gameObject.SetActive(false);
                // Activate the shovel on the player
                ShovelOnPlayer.SetActive(true);
                display.gameObject.SetActive(false);

                // Log to confirm the actions
                Debug.Log("Shovel picked up and attached to player");
            }
        }
        else
            display.gameObject.SetActive(false);
    }
}