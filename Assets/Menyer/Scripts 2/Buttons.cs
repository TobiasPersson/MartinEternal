using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    bool inGame;

    //Start the game from start menu or restart the game from death menu
    public void Play()
    {
        SceneManager.LoadScene("", LoadSceneMode.Single);
        inGame = true;
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
        inGame = false;
    }

    //Unpausing the game and unloading pause menu
    public void Resume()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1;
    }

    //Unload the options menu (either to pause or start menu from options)
    public void Back()
    {
        SceneManager.UnloadSceneAsync("Options");
    }

    //Pressing escape in the game (make a bool that is true when starting the game and false otherwise) opens the pause menu
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inGame)
        {
            SceneManager.LoadScene("", LoadSceneMode.Additive);
            Time.timeScale = 0;
        }
    }
    
}
