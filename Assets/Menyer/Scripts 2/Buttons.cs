using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //Start the game from start menu or restart the game from death menu
    public void Play()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    //Options on top of current scene from main menu or pause menu
    public void Options()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }

    //Exit the game from main menu
    public void Quit()
    {
        Application.Quit();
    }

    //Back to the start menu from the pause menu and death menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    //Unload the options menu
    public void Back()
    {
        SceneManager.UnloadSceneAsync("Options");
    }

    /*
    //Unpausing the game and unloading pause menu
    public void Resume()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1;
    }
    */
}
