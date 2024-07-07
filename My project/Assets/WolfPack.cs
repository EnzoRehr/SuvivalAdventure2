using UnityEngine;
using System.Collections.Generic;

public class WolfPack : MonoBehaviour
{
    [Header("Settings")]
    public GameObject wolfPrefab;
    public Transform[] cornerTransforms;
    public int numberOfWolves = 5;

    private List<GameObject> wolves = new List<GameObject>();

    void Start()
    {
        if (cornerTransforms.Length != 4)
        {
            Debug.LogError("Exactly 4 corner transforms are required!");
            return;
        }

        SpawnWolves();
    }

    void SpawnWolves()
    {
        for (int i = 0; i < numberOfWolves; i++)
        {
            Vector3 spawnPosition = GetRandomPositionInArea();
            GameObject wolf = Instantiate(wolfPrefab, spawnPosition, Quaternion.identity);
            wolves.Add(wolf);

            // Set initial state to IdleState
            StateManager stateManager = wolf.GetComponent<StateManager>();
            IdleState idleState = wolf.GetComponent<IdleState>();

            if (idleState != null)
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

                stateManager.currentState = idleState;
            }
           
        }
    }

    Vector3 GetRandomPositionInArea()
    {
        float xMin = Mathf.Min(cornerTransforms[0].position.x, cornerTransforms[1].position.x, cornerTransforms[2].position.x, cornerTransforms[3].position.x);
        float xMax = Mathf.Max(cornerTransforms[0].position.x, cornerTransforms[1].position.x, cornerTransforms[2].position.x, cornerTransforms[3].position.x);
        float zMin = Mathf.Min(cornerTransforms[0].position.z, cornerTransforms[1].position.z, cornerTransforms[2].position.z, cornerTransforms[3].position.z);
        float zMax = Mathf.Max(cornerTransforms[0].position.z, cornerTransforms[1].position.z, cornerTransforms[2].position.z, cornerTransforms[3].position.z);

        float x = Random.Range(xMin, xMax);
        float z = Random.Range(zMin, zMax);
        float y = cornerTransforms[0].position.y; // Assuming the terrain is flat

        return new Vector3(x, y, z);
    }

    void Update()
    {
        // Example update logic for wolves
        foreach (var wolf in wolves)
        {
            // You can add update logic for each wolf here if needed
        }
    }
}