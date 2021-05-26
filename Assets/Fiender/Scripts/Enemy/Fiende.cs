using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fiende : MonoBehaviour
{
    [SerializeField]
    public EnemyData EnemyData;
    
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = EnemyData.MovementSpeed;
    }
}
