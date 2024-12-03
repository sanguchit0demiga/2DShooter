using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioClip buttonClickSound;
    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void Back()
    {
        Debug.Log("Back button pressed");
        PlayButtonClickSound();
        StartCoroutine(LoadSceneWithDelay(0));
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
