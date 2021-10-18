using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigGuyMovement : FiendeMovement
{
    [Header("Jump")]
    [SerializeField]
    private float jumpThreshold;

    [SerializeField]
    private float jumpHeight;

    [SerializeField]
    private float jumpLength;

    [SerializeField]
    private float jumpSpeed;

    protected override void Update()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            if (!InRange())
            {
                if (agent.isOnNavMesh)
                {
                    SetAgentPath();

                    if (Vector3.Distance(transform.position, player.transform.position) >= jumpThreshold)
                    {
                        Jump();
                    }
                }
            }
            else if (moving)
            {
                moving = false;
                OnRangeIn();
            }
        }
    }

    private void Jump()
    {
        
    }
}
