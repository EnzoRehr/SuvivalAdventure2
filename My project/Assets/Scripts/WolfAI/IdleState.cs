using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : WolfStates
{
    public ChaseState chaseState;
    public GameObject wolf;         // Reference to the Wolf GameObject
    public Transform player;
    public float viewRadius = 10f;
    public float viewAngle = 120f;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public float patrolWaitTime = 3f;

    private NavMeshAgent navMeshAgent;
    private bool patrolPointSet;
    private Vector3 patrolPoint;
    private float patrolTimer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = wolf.GetComponent<NavMeshAgent>();
        patrolTimer = 0f;
        patrolPointSet = false;
    }

    public override WolfStates RunCurrentState()
    {
        Patrol();

        if (CanSeePlayer())
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    private void Patrol()
    {
        if (patrolPointSet)
        {
            navMeshAgent.SetDestination(patrolPoint);

            // Check if the wolf has reached the patrol point
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                patrolPointSet = false;
                patrolTimer = 0f;
            }
        }
        else
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer >= patrolWaitTime)
            {
                patrolPointSet = true;
                // Choose a random point within a range and set it as the patrol point
                Vector3 randomPoint = transform.position + Random.insideUnitSphere * 10f;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
                {
                    patrolPoint = hit.position;
                }
            }
        }
    }

    public void SetNavMeshAgent(NavMeshAgent agent)
    {
        navMeshAgent = agent;
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