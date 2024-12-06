using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TMP_Text enemiesKilledText; 
    private static int enemiesKilled = 0;
    public int enemiesToWin = 20;

    void Start()
    {
        UpdateEnemiesKilledText(); 
    }


    public static void EnemyKilled()  
    {
        enemiesKilled++; 

       
        FindObjectOfType<GameController>().UpdateEnemiesKilledText();

        
        if (enemiesKilled >= FindObjectOfType<GameController>().enemiesToWin)
        {
            FindObjectOfType<GameController>().Victory(); 
        }
    }




    void UpdateEnemiesKilledText()
    {
        enemiesKilledText.text = "Cats killed: " + enemiesKilled; 
    }

    void Victory()
    {

        SceneManager.LoadScene("Win");
    }
}