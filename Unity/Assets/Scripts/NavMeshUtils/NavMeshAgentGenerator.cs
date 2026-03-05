using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentSpawner : MonoBehaviour
{
    [SerializeField]private NavMeshAgent agentPrefab; 
    [SerializeField]private float radius = 10f;
    [SerializeField] private int _count;

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            Vector3 spawnPosition = GetRandomPointOnNavMesh(transform.position);

            if (spawnPosition != transform.position) // Ensure a valid point was found
                Instantiate(agentPrefab, spawnPosition, Quaternion.identity);
            else
            {
                Debug.LogWarning("Could not find a valid NavMesh point within the radius.");
                
            }
        }
    }

    private Vector3 GetRandomPointOnNavMesh(Vector3 center)
    {
        var randomDirection = Random.insideUnitSphere * radius;
        randomDirection += center;

        return NavMesh.SamplePosition(randomDirection, out var hit, radius, NavMesh.AllAreas) ? hit.position :
            // Return a fallback value (e.g., the center) if no valid point is found
            center;
    }
}
