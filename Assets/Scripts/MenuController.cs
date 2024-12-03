using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioClip buttonClickSound;


    public void StartGame()
    {
        PlayButtonClickSound();
        StartCoroutine(LoadSceneWithDelay(2));
    }
    public void QuitGame()
    {
        PlayButtonClickSound();
        Application.Quit();
    }

    public void Options()
    {
        PlayButtonClickSound();

        StartCoroutine(LoadSceneWithDelay(1));
    }
    public void PlayButtonClickSound()
    {
        if (SFXSource != null && buttonClickSound != null)
        {
            SFXSource.PlayOneShot(buttonClickSound);

        }
    }
    IEnumerator LoadSceneWithDelay(int sceneIndex)
    {
        yield return new WaitForSeconds(buttonClickSound.length); 
        SceneManager.LoadScene(sceneIndex);
    }
}