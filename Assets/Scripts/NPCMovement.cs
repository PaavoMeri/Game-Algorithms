using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent ourAgent;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        ourAgent = GetComponent<NavMeshAgent>();
        lastPlayerPosition = player.position;
    }

    void Update()
    {
        // Check if the player has moved significantly before updating the destination
        if (Vector3.Distance(player.position, lastPlayerPosition) > 1.0f) 
        {
            ourAgent.SetDestination(player.position);
            lastPlayerPosition = player.position;
        }
    }
}

