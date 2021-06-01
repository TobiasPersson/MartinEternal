using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private bool targetIsCamera = false;

    private void Awake()
    {
        if (targetIsCamera)
        {
            target = Camera.main.transform;
            transform.LookAt(target);
        }
    }

    void Update()
    {
        transform.LookAt(target);
    }
}
