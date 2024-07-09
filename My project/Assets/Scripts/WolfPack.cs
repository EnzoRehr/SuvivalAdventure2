using UnityEngine;
using System.Collections.Generic;

public class WolfPack : MonoBehaviour
{
    [Header("Settings")]
    public GameObject wolfPrefab;
    public Transform[] cornerTransforms;
    public int numberOfWolves = 3;

    private List<GameObject> wolves = new List<GameObject>();

    private Vector3 minBound;
    private Vector3 maxBound;

    void Start()
    {
        if (cornerTransforms.Length != 4)
        {
            Debug.LogError("Exactly 4 corner transforms are required!");
            return;
        }

        CalculateBounds();
        SpawnWolves();
    }

    void CalculateBounds()
    {
        minBound = new Vector3(
            Mathf.Min(cornerTransforms[0].position.x, cornerTransforms[1].position.x, cornerTransforms[2].position.x, cornerTransforms[3].position.x),
            cornerTransforms[0].position.y,
            Mathf.Min(cornerTransforms[0].position.z, cornerTransforms[1].position.z, cornerTransforms[2].position.z, cornerTransforms[3].position.z)
        );

        maxBound = new Vector3(
            Mathf.Max(cornerTransforms[0].position.x, cornerTransforms[1].position.x, cornerTransforms[2].position.x, cornerTransforms[3].position.x),
            cornerTransforms[0].position.y,
            Mathf.Max(cornerTransforms[0].position.z, cornerTransforms[1].position.z, cornerTransforms[2].position.z, cornerTransforms[3].position.z)
        );
    }

    void SpawnWolves()
    {
        for (int i = 0; i < numberOfWolves; i++)
        {
            Vector3 spawnPosition = GetRandomPositionInArea();
            GameObject wolf = Instantiate(wolfPrefab, spawnPosition, Quaternion.identity);
            wolves.Add(wolf);

            // Set initial state to IdleState
            StateManager stateManager = wolf.GetComponentInChildren<StateManager>();
            IdleState idleState = wolf.GetComponentInChildren<IdleState>();

            if (stateManager != null && idleState != null)
            {
                idleState.wolf = wolf; // Assign the wolf GameObject reference
                idleState.player = GameObject.FindGameObjectWithTag("Player").transform;
                idleState.patrolWaitTime = 3f; // Set your patrol wait time here

                // Assuming your wolfPrefab has a NavMeshAgent component
                UnityEngine.AI.NavMeshAgent navMeshAgent = wolf.GetComponent<UnityEngine.AI.NavMeshAgent>();
                if (navMeshAgent != null)
                {
                    idleState.SetNavMeshAgent(navMeshAgent);
                }

                idleState.SetBounds(minBound, maxBound); // Set the patrol area bounds
                stateManager.currentState = idleState;
            }
            else
            {
                Debug.LogError("StateManager or IdleState component not found on wolf prefab.");
            }
        }
    }

    Vector3 GetRandomPositionInArea()
    {
        float x = Random.Range(minBound.x, maxBound.x);
        float z = Random.Range(minBound.z, maxBound.z);
        float y = cornerTransforms[0].position.y; // Assuming the terrain is flat

        return new Vector3(x, y, z);
    }
}
