using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : WolfStates
{
    public AttackState attackState;
    public Transform player;
    public float attackRange = 2f;  // Distance at which the wolf will switch to AttackState
    public float moveSpeed = 5f;    // Speed at which the wolf moves towards the player
    public LayerMask playerMask;    // Layer mask to identify the player
    public LayerMask obstacleMask;  // Layer mask to identify obstacles
    public GameObject wolf;         // Reference to the Wolf GameObject
    public GameObject wolfModel;    // Reference to the 3D model of the wolf for coloring

    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        // Find the player by tag (assuming the player GameObject is tagged as "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent component from the wolf GameObject
        navMeshAgent = wolf.GetComponent<NavMeshAgent>();

        // Set the speed of the NavMeshAgent
        navMeshAgent.speed = moveSpeed;
    }

    public override WolfStates RunCurrentState()
    {
        if (IsInAttackRange())
        {
            // Revert the color back before transitioning
           
            return attackState;
        }
        else
        {
            ChasePlayer();
            // Change the color of the wolf to yellow while chasing
            Sprinting();
            return this;
        }
    }

    private bool IsInAttackRange()
    {
        float distanceToPlayer = Vector3.Distance(wolf.transform.position, player.position);
        return distanceToPlayer <= attackRange;
    }

    private void ChasePlayer()
    {
        // Set the NavMeshAgent destination to the player's position
        navMeshAgent.SetDestination(player.position);
    }


    private void Sprinting()
    {
        wolfModel.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
