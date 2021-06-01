using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint_handler : MonoBehaviour
{
    private void OnMouseDown() {
        print("Clikc");
        GameManager.Instance.PlayerSpawnArea(transform.GetChild(0).position);
        
    }
}
