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
    protected float range = 1;

    protected NavMeshAgent agent;
    protected Transform player;

    protected bool moving = false;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    protected virtual void Update()
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

    protected void SetAgentPath()
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(player.position - new Vector3(0, player.transform.localScale.y / 2, 0), path);
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

    protected bool InRange()
    {
        return Vector3.Distance(transform.position, player.position) < range;
    }

    protected void OnRangeIn()
    {
        OnInRange();
    }
}
