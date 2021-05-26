using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// A Singleton class, because I'm lazy. T is the class we want to be a Singleton
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);

            SceneManager.activeSceneChanged += OnSceneChanged;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected abstract void OnSceneChanged(Scene currentScene, Scene nextScene); // Initialization, say we wan't a reference to the player, that will be destroyed if we switch scenes but this won't also code in start won't run. Thus <---
}
