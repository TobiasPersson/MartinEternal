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
    private float range = 1;

    private NavMeshAgent agent;
    private Transform player;

    private bool moving = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;
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
        agent.CalculatePath(player.position, path);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            print("Path set");
            agent.path = path;
            moving = true;

            OnOutOfRange();
        }
        else
        {
            print("Enemy could not find path to player");
        }
    }

    private bool InRange()
    {
        return Vector3.Distance(transform.position, player.position) < range;
    }
}
