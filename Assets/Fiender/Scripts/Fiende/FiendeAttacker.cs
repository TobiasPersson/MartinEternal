using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiendeAttacker : MonoBehaviour
{
    private Fiende fiende;
    private FiendeMovement fiendeMovement;
    private FiendeAttackAnimationTrigger attackTrigger;

    private Animator animator;

    private Collider[] results;

    private float attackColliderOffset = 2;
    private float attackRadius = 1;

    private bool inRange = false;
    private float timer = 0;

    private void Awake()
    {
        fiende = GetComponent<Fiende>();

        fiendeMovement = GetComponent<FiendeMovement>();
        fiendeMovement.OnInRange += FiendeMovement_OnInRange;
        fiendeMovement.OnOutOfRange += FiendeMovement_OnOutOfRange;

        attackTrigger = GetComponentInChildren<FiendeAttackAnimationTrigger>();
        attackTrigger.OnAttackTrigger += AttackTrigger_OnAttackTrigger;

        animator = GetComponentInChildren<Animator>();

        results = new Collider[5]; // The results collider can hold five memes
    }

    private void FixedUpdate()
    {
        if (inRange)
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f / fiende.EnemyData.AttackSpeed)
            {
                timer = 0;
                animator.SetTrigger("Attack");
            }
        }
    }

    private void FiendeMovement_OnOutOfRange()
    {
        inRange = false;
    }

    private void FiendeMovement_OnInRange()
    {
        inRange = true;
        timer =  (1.0f / fiende.EnemyData.AttackSpeed) * 0.5f;
    }

    private void AttackTrigger_OnAttackTrigger()
    {
        DealDamage();
    }

    private void DealDamage()
    {
        Physics.OverlapSphereNonAlloc(transform.position + attackColliderOffset * transform.forward, attackRadius, results);
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i] == null)
            {
                continue;
            }

            var takeDamage = results[i].gameObject.GetComponent<ITakeDamage>();
            if (takeDamage != null)
            {
                takeDamage.TakeDamage(fiende.EnemyData.Damage, false);
            }
        }
    }

   
}
