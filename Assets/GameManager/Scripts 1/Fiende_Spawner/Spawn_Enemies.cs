using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawn_Enemies : MonoBehaviour
{
    public List<EnemySpawnData> enemyList_spawner = new List<EnemySpawnData>();
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
        if (isWaveCleared == true)
        {
            time += Time.deltaTime;
            if (time >= timeLimit)
            {
                GenerateRandomEnemy();
                time = 0;
            }
        }
    }

    public void WaveCompleted()
    {
        isWaveCleared = true;
    }

    public void GenerateRandomEnemy()
    {        
        waveAmount = Mathf.RoundToInt(Mathf.Pow(waveAmount, waveExponant));
        
        for (int i = 0; i < waveAmount; i++)
        {  
            float num = Random.Range(0.0f, 1.0f);
            EnemySpawnData chosenEnemy = enemyList_spawner[0];

            for (int g = 0; g < enemyList_spawner.Count; g++)
            {
                if (enemyList_spawner[g].Weight >= num && enemyList_spawner[g].Weight <= chosenEnemy.Weight)
                {
                    chosenEnemy = enemyList_spawner[g];
                }
            }

            int spawn_random = Random.Range(0, spawnPointsList_spawner.Count);
        
            Instantiate(chosenEnemy.Enemy, spawnPointsList_spawner[spawn_random].transform.position, Quaternion.identity);

            isWaveCleared = false;
        }

        GameManager.Instance.OnWaveStarted(waveAmount);
    }
}

[System.Serializable]
public struct EnemySpawnData
{
    public Fiende Enemy;
    public float Weight;
}
