using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioClip buttonClickSound;
    public void QuitGame()
    {
        PlayButtonClickSound();
        Application.Quit();
    }

    public void Restart()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("Game");

    }

    private void PlayButtonClickSound()
    {
        if (SFXSource != null && buttonClickSound != null)
        {
            SFXSource.PlayOneShot(buttonClickSound);
        }
    }
    private IEnumerator RestartWithDelay()
    {
        yield return new WaitForSeconds(buttonClickSound.length);
        SceneManager.LoadScene("Game");
    }
}
