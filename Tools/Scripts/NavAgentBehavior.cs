using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3Data playerLoc;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void ChangeDestination(Vector3Data newLoc)
    {
        playerLoc = newLoc;
    }
    
    void Update()
    {
        agent.destination = playerLoc.value;
    }

}
