using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawn_Enemies : MonoBehaviour
{
    public List<GameObject> enemyList_spawner = new List<GameObject>();
    public List<GameObject> spawnPointsList_spawner = new List<GameObject>();
    [SerializeField]
    private float time = 0.0f;
    [SerializeField]
    private float timeLimit;
    [SerializeField]
    private bool isWaveCleared = false;
    void Update()
    {
        time += Time.deltaTime;
        if(time >= timeLimit){
            generateRandomEnemy();
            time = 0;
        }
    }

    public void generateRandomEnemy(){
        for(int i = 0; i < 3; i++){  
        int enemy_random = Random.Range(0, enemyList_spawner.Count);
        int spawn_random = Random.Range(0, spawnPointsList_spawner.Count);
        
        Instantiate(enemyList_spawner[enemy_random], spawnPointsList_spawner[spawn_random].transform.position, Quaternion.identity);

        isWaveCleared = false;
        }
    }
}
