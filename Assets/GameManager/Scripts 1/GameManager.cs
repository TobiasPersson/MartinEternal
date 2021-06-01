using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int count = 0;
    protected override void OnSceneChanged(Scene currentScene, Scene nextScene)
    {
        
    }

    public void OnWaveStarted(int enymiesspawnd){
        count = enymiesspawnd;
    }

    public void OnDeath(Fiende fiende){
        count -= 1;
        if(count == 0)
        {
            WabvComplete();

        }
        Debug.Log("THis has happened");
    }

    private void WabvComplete()
    {
        FindObjectOfType<Spawn_Enemies>().WaveCompleted();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.K)){
            WabvComplete();
        }
    }

}
