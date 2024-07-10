using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TicketCollectorHandOver : MonoBehaviour
{
    public bool CollectorSatisfied = false;
    public TextMeshProUGUI display;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player detected");
            display.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("F key pressed");
                display.gameObject.SetActive(false);
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
        else
            display.gameObject.SetActive(false);
    }
}