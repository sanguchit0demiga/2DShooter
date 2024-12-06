using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Gameover : MonoBehaviour
{
    
    public void QuitGame()
    {
        
        Application.Quit();
    }

    public void Restart()
    {

        SceneManager.LoadScene("Game");
        
    }
}





