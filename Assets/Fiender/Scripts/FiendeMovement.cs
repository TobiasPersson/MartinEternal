using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FiendeMovement : MonoBehaviour
{
    public event Action OnInRange = delegate { };
    public event Action OnOutOfRange = delegate { };

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float range = 1;

    private NavMeshAgent agent;

    private bool moving = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            if (!InRange())
            {
                if (agent.isOnNavMesh)
                {
                    SetAgentPath();
                }
            }
            else if (moving)
            {
                moving = false;
                OnInRange();
            }
        }

    }

    private void SetAgentPath()
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(target.position, path);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            print("Path set");
            agent.path = path;
            moving = true;

            OnOutOfRange();
        }
    }

    private bool InRange()
    {
        return Vector3.Distance(transform.position, target.position) < range;
    }
}
