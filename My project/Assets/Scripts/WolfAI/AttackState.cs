using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : WolfStates
{
    public ChaseState chaseState;    // Reference to the ChaseState
    public Transform player;         // Reference to the player's Transform
    public float attackRange = 5f;   // Distance at which the wolf will switch to ChaseState
    public GameObject wolf;          // Reference to the Wolf GameObject
    public GameObject wolfModel;     // Reference to the 3D model of the wolf for coloring
    public GameObject jaws;          // Reference to the jaws GameObject
    private Animator animator;       // Reference to the Animator component on jaws
    private bool isAttacking = false;
    private Coroutine attackCoroutine; // Reference to the current attack coroutine


    private void Start()
    {
        // Find the player by tag (assuming the player GameObject is tagged as "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the Animator component from the jaws GameObject
        animator = jaws.GetComponent<Animator>();

        // Ensure the jaws GameObject has an Animator component
        if (animator == null)
        {
            Debug.LogError("Animator component missing from jaws GameObject.");
        }
    }

    public override WolfStates RunCurrentState()
    {
        // Start the attacking coroutine if not already attacking
        if (!isAttacking)
        {
            attackCoroutine = StartCoroutine(Attacking());
        }

        // Check if the player is within the attack range
        if (!IsInAttackRange())
        {
            // If the player exits the attack range, stop attacking and return the ChaseState
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                isAttacking = false;
            }
            return chaseState;
        }

        // Remain in the AttackState
        return this;
    }

    private bool IsInAttackRange()
    {
        float distanceToPlayer = Vector3.Distance(wolf.transform.position, player.position);
        return distanceToPlayer <= attackRange;
    }

    private IEnumerator Attacking()
    {
        isAttacking = true;
        while (true)
        {
            // Change the WolfModel color to red
            wolfModel.GetComponent<Renderer>().material.color = Color.red;

            // Trigger the "Bite" animation if the Animator component is available
            if (animator != null)
            {
                animator.SetTrigger("Bite");
            }

            // Wait for 1 second before enabling the jaws collider
            yield return new WaitForSeconds(1f);
            EnableJawsCollider();
            Debug.Log("Jaws Collider Enabled");

            // Wait for another second before disabling the jaws collider
            yield return new WaitForSeconds(1f);
            DisableJawsCollider();
            Debug.Log("Jaws Collider Disabled");

            // Reset the damage flag after the collider is disabled
       

            // Wait for the rest of the bite animation duration
            yield return new WaitForSeconds(1f); // Assuming the bite animation is 3 seconds long
        }
    }

   

    // Ensure the collider for the jaws is enabled only during the bite animation
    private void EnableJawsCollider()
    {
        Collider collider = jaws.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = true;
        }
        else
        {
            Debug.LogError("Collider component missing from jaws GameObject.");
        }
    }

    private void DisableJawsCollider()
    {
        Collider collider = jaws.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }
        else
        {
            Debug.LogError("Collider component missing from jaws GameObject.");
        }
    }
}