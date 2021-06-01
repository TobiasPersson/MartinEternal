using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fiende))]
public class FiendeHealth : Health
{
    [SerializeField]
    private PooledMonoBehaviour deathParticles;

    public float DeathAnimationLength = 1;

    private Fiende enemy;
    private Animator animator;

    private void Awake()
    {
        enemy = GetComponent<Fiende>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        HealthData.maxHealth = enemy.EnemyData.MaxHealth /*+ Mathf.RoundToInt(GameManager.Instance.WaveCount * enemy.EnemyData.HealthScaling)*/;
        HealthData.currentHealth = HealthData.maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(2);
        }
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);

        transform.position -= transform.forward * ((amount + 1) / 4.0f);
    }

    public override void Die()
    {
        StartCoroutine(PlayDeathAnimation());
    }

    private IEnumerator PlayDeathAnimation()
    {
        animator.SetTrigger("Dö");
        yield return new WaitForSeconds(DeathAnimationLength * 0.8f);

        deathParticles.GetAtPosAndRot<PooledMonoBehaviour>(transform.GetChild(0).position, Quaternion.identity);

        yield return new WaitForSeconds(DeathAnimationLength * 0.2f);

        GameManager.Instance.OnDeath(enemy);

        gameObject.SetActive(false);
    }
}
