using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool GamePaused = false;

    public GameObject PauseCanvas;
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseCanvas.SetActive(true);
        GamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
        GamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        ResumeGame();
    }
    private void Update()
    {
        if (!GamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        else if (GamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }

}
