using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FiendeJumpment : FiendeMovement
{
    [Header("Jump")]
    [SerializeField]
    private float jumpThreshold = 20;

    [SerializeField]
    private float jumpDistance = 15;

    [SerializeField]
    private float jumpChargeTime = 1f;

    [SerializeField]
    private float jumpHeight = 3;

    [SerializeField]
    private float jumpSpeed = 10;

    [SerializeField]
    private float cooldown = 30;

    [Header("Jump Damage")]
    [SerializeField]
    private int jumpDamage = 10;

    [SerializeField]
    private float damageRadius = 5;

    [Header("Effects")]
    [SerializeField]
    private PooledMonoBehaviour landParticle;

    private Collider[] results;

    private float timer = 0;
    private bool hasJumped = false;

    private void Awake()
    {
        results = new Collider[10];
    }

    protected override void Update()
    {
        if (!hasJumped)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= jumpThreshold)
            {
                hasJumped = true;
                StartCoroutine(Jump());
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                timer = 0;
                hasJumped = false;
            }
        }

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
                    CallOnInRange();
                }
            }
        }
    }

    private IEnumerator Jump()
    {
        agent.isStopped = true;

        yield return new WaitForSeconds(jumpChargeTime);

        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = player.transform.position;
        Vector3 direction = (originalPosition - targetPosition).normalized;
        targetPosition -= (jumpThreshold - jumpDistance) * -direction;

        Vector3 heightPoint = Vector3.Lerp(originalPosition, targetPosition, 0.5f) + Vector3.up * jumpHeight;

        float t = 0;

        while (t <= 1)
        {
            t += Time.deltaTime * (jumpSpeed / jumpDistance);

            transform.position = Vector3.Lerp(Vector3.Lerp(originalPosition, heightPoint, t), Vector3.Lerp(heightPoint, targetPosition, t), t);

            yield return null;
        }

        JumpDamage();
        landParticle.GetAtPosAndRot<PooledMonoBehaviour>(transform.position, Quaternion.identity);

        agent.isStopped = false;
    }

    private void JumpDamage()
    {
        Physics.OverlapSphereNonAlloc(transform.position, damageRadius, results);
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i] == null)
            {
                continue;
            }

            var takeDamage = results[i].gameObject.GetComponent<ITakeDamage>();
            if (takeDamage != null)
            {
                takeDamage.TakeDamage(jumpDamage, false);
            }
        }
    }
}
