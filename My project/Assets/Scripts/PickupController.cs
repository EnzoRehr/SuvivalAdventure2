using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    /*
    public Shovel shovelScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Update()
    {
        Vector3 distanceToPlayer= player.position- transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.F) && !slotFull)
            PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.G))
            Drop();
    }


    private void PickUp()
    {
        equipped = true;
        slotFull = true;
        rb.isKinematic = true;
        coll.isTrigger = true;

        shovelScript.enable = true; 
    }


    private void Drop()
    {
        equipped = false;
        slotFull = false;
        rb.isKinematic = false;
        coll.isTrigger = false;

        shovelScript.enable = false;
    }

    */





}
