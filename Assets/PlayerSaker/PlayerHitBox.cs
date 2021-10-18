using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var takeDamage = other.GetComponent<ITakeDamage>();
        if(takeDamage != null)
        {
            takeDamage.TakeDamage(5);
        }
    }
}
