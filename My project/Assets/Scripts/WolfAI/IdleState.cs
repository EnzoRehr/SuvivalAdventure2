using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : WolfStates
{
    public ChaseState chaseState;
    public Transform player;       // Reference to the player's transform
    public float viewRadius = 10f; // Radius within which the wolf can see the player
    public float viewAngle = 120f; // Angle within which the wolf can see the player
    public LayerMask playerMask;   // Layer mask to identify the player
    public LayerMask obstacleMask; // Layer mask to identify obstacles
    public NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent

    private void Start()
    {
        // Find the player by tag (assuming the player GameObject is tagged as "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent component from the wolf GameObject
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override WolfStates RunCurrentState()
    {
        if (CanSeePlayer())
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < viewRadius)
        {
            float angleBetweenWolfAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleBetweenWolfAndPlayer < viewAngle / 2f)
            {
                // Check if there are no obstacles blocking the view
                if (!Physics.Linecast(transform.position, player.position, obstacleMask))
                {
                    return true;
                }
            }
        }

        return false;
    }

    // This method is optional and helps visualize the field of view in the Scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2f, 0) * transform.forward * viewRadius;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2f, 0) * transform.forward * viewRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}