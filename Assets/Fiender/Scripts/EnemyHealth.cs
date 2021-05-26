using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fiende))]
public class EnemyHealth : Health
{
    public float DeathAnimationLength = 1; // So we never got a death animation, that's unfortunate

    private Fiende enemy;

    private void Awake()
    {
        enemy = GetComponent<Fiende>();
    }

    private void OnEnable()
    {
        HealthData.maxHealth = enemy.EnemyData.MaxHealth + Mathf.RoundToInt(GameManager.Instance.WaveCount * enemy.EnemyData.HealthScaling);
        HealthData.currentHealth = HealthData.maxHealth;
    }

    public override void Die()
    {
        StartCoroutine(PlayDeathAnimation());
    }

    private IEnumerator PlayDeathAnimation()
    {
        yield return new WaitForSeconds(0.01f);

        gameObject.SetActive(false);
    }
}
