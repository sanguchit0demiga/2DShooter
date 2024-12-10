using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject coinCounterText;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameController gameController;

    public static int coinsCollected = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        GamePaused = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        AudioListener.pause = true;
        healthBar.SetActive(false);
        scoreText.SetActive(false);
        coinCounterText.SetActive(false);
        coin.SetActive(false);
    }

    public void Resume()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
        healthBar.SetActive(true);
        scoreText.SetActive(true);
        coinCounterText.SetActive(true);
        coin.SetActive(true);
        coinsCollected = 0;

    }

    public void Restart()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioListener.pause = false;
        if (gameController != null)
        {
            gameController.ResetGame();
        }

    }

    public void Quit()
    {
        Application.Quit();
    }
}
