using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    private bool gamePaused = false;
    [SerializeField] private AudioSource backgroundMusic;

    public void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePaused) {   
                Resume();
                 }
            else {
                Pause();
            }

        }
    }

    public void Pause()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        backgroundMusic.Pause();
    }

    public void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        backgroundMusic.UnPause();
    }

    public void Restart()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
       Application.Quit();
    }
}
