using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private enum State { Chase, Flee, ProximityChase }
    private State currentState;
    private NavMeshAgent agent;
    public Transform player;

    public float chaseDistance = 10f;  // Distance to start chasing
    public float escapeDistance = 15f; // Distance at which the player escapes

    private Vector3 startPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        currentState = State.ProximityChase;
    }

    void Update()
    {
        // Check for state change key presses
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(State.Chase);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(State.Flee);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(State.ProximityChase);
        }

        // Execute current state behavior
        switch (currentState)
        {
            case State.Chase:
                ChasePlayer();
                break;
            case State.Flee:
                FleePlayer();
                break;
            case State.ProximityChase:
                ProximityChase();
                break;
        }
    }

    private void SetState(State newState)
    {
        currentState = newState;
        Debug.Log($"NPC Mode: {newState}");
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

    private void ProximityChase()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);

        if (playerDistance <= chaseDistance)
        {
            agent.SetDestination(player.position);
        }
        else if (playerDistance > escapeDistance)
        {
            agent.SetDestination(startPosition);
        }
    }
}





