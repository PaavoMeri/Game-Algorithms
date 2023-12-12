using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private enum State { Chase, Flee, StandStill }
    private State currentState;
    private NavMeshAgent agent;
    public Transform player;

    public float chaseDistance = 10f;  // Distance to start chasing
    public KeyCode toggleKey = KeyCode.T; // Key to toggle behavior

    private Vector3 startPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        currentState = State.StandStill;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Chase:
                ChasePlayer();
                break;
            case State.Flee:
                FleePlayer();
                break;
            case State.StandStill:
                StandStill();
                break;
        }

        if (Input.GetKeyDown(toggleKey))
        {
            ToggleState();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void FleePlayer()
    {
        Vector3 fleeDirection = transform.position - player.position;
        Vector3 newTarget = transform.position + fleeDirection;
        agent.SetDestination(newTarget);
    }

    private void StandStill()
    {
        if (Vector3.Distance(transform.position, player.position) <= chaseDistance)
        {
            currentState = State.Chase;
        }
        else
        {
            agent.SetDestination(startPosition);
        }
    }

    private void ToggleState()
    {
        currentState = (State)(((int)currentState + 1) % 3);
        switch (currentState)
        {
            case State.Chase:
                Debug.Log("NPC Mode: Chase");
                break;
            case State.Flee:
                Debug.Log("NPC Mode: Flee");
                break;
            case State.StandStill:
                Debug.Log("NPC Mode: Stand Still");
                break;
        }
    }
}


