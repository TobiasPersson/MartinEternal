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
    private bool isWaveCleared = true;
    public int waveAmount = 0;
    public float waveExponant = 1.02f;
    private GameManager gameManager;
   private void Update()
    {
        if(isWaveCleared == true){
            time += Time.deltaTime;
            if(time >= timeLimit){
                generateRandomEnemy();
                time = 0;
            }
        }
    }
    public void WaveCompleted()
    {
        isWaveCleared = true;
    }

    public void generateRandomEnemy(){        
        waveAmount = Mathf.RoundToInt(Mathf.Pow(waveAmount, waveExponant));
        
        for(int i = 0; i < waveAmount; i++){  
        int enemy_random = Random.Range(0, enemyList_spawner.Count);
        int spawn_random = Random.Range(0, spawnPointsList_spawner.Count);
        
        Instantiate(enemyList_spawner[enemy_random], spawnPointsList_spawner[spawn_random].transform.position, Quaternion.identity);

        isWaveCleared = false;
        }

        GameManager.Instance.OnWaveStarted(waveAmount);
    }
}
