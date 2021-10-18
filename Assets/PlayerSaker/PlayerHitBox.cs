using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    public ITakeDamage takenDamage;
    private void OnTriggerEnter(Collider other)
    {
        var takeDamage = other.GetComponent<ITakeDamage>();
        takeDamage = takenDamage;
        if(takeDamage != null)
        {
            
            takeDamage.TakeDamage(5);
        }
    }
}
