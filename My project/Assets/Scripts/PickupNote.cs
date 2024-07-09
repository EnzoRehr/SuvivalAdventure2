using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupNote : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Letter;

    // Update is called once per frame

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

                Letter.SetActive(true);
                Time.timeScale = 0.0f;
            }                                             
        }
    }    
}
