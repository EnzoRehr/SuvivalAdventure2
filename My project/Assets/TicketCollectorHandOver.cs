using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketCollectorHandOver : MonoBehaviour
{
    public bool CollectorSatisfied = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player detected");

            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("F key pressed");

                PlayerInventory PI = other.GetComponentInParent<PlayerInventory>();
                if (PI != null && PI.tickets > 0)
                {
                    CollectorSatisfied = true;
                }
                else
                    if(PI==null)
                {
                    Debug.LogError("PI not found");
                }
            }
        }
    }
}