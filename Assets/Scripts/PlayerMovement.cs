using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement: MonoBehaviour
{
    private NavMeshAgent ourAgent;

    void Start()
    {
        ourAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                ourAgent.SetDestination(hit.point);
            }
        }
    }
}
