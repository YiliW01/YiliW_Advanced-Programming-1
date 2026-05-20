using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }


    public void Move(Vector3 pos)
    {
        // var to store path info
        NavMeshPath path = new NavMeshPath();
        // first calc to our destination without moving the navAgent
        navAgent.CalculatePath(pos, path);

        // Based on the result of path calc, decide if we move navAgent
        switch (path.status)
        {
            case NavMeshPathStatus.PathComplete:
                Debug.Log("Path is valid, agent moving...");
                navAgent.SetDestination(pos);
                navAgent.isStopped = false;
                break;
            case NavMeshPathStatus.PathPartial:
                Debug.Log("Incomplete path, stopping agent...");
                navAgent.isStopped = true;
                break;
            case NavMeshPathStatus.PathInvalid:
                Debug.Log("Invalid path, stopping agent...");
                navAgent.isStopped = true;
                break;
        }
    }
}
