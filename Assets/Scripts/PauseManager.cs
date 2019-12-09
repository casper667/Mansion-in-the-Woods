using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject fadedBackground;

    private bool IsPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        fadedBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        gameUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        fadedBackground.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause()
    {
        gameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        fadedBackground.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}