using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    private FiendeMovement fiendeMovement;

    private bool inRange = false;

    private void Awake()
    {
        fiendeMovement = GetComponent<FiendeMovement>();
        fiendeMovement.OnInRange += FiendeMovement_OnInRange;
        fiendeMovement.OnOutOfRange += FiendeMovement_OnOutOfRange;
    }

    private void FiendeMovement_OnOutOfRange()
    {
        inRange = false;
    }

    private void FiendeMovement_OnInRange()
    {
        inRange = true;
    }
}
