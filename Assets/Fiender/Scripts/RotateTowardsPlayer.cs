using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private bool targetIsPlayer = false;

    private void Awake()
    {
        if (targetIsPlayer)
        {
            target = FindObjectOfType<PlayerMovement>().transform;
            transform.LookAt(target);
        }
    }

    void Update()
    {
        transform.LookAt(target);
    }
}
