using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TMP_Text enemiesRemainingText;
    private static int enemiesRemaining = 20;  
    public int totalEnemies = 20;  
    public TMP_Text coinScoreText;
    private static int coinScore = 0;


    [SerializeField] private float playerHealth = 100f;
    [SerializeField] private float maxHealth = 100f;

    void Start()
    {
        UpdateEnemiesRemainingText();

        UpdateCoinScoreText();
    }

   
    public void IncreasePlayerHealth(float amount)
    {
        playerHealth += amount;

       
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }


    }

    public static void EnemyKilled()
    {
        enemiesRemaining--;  
        FindObjectOfType<GameController>().UpdateEnemiesRemainingText(); 

      
        if (enemiesRemaining <= 0)
        {
            FindObjectOfType<GameController>().Victory();
        }
    }

    public void IncreaseCoinScore(int amount)
    {
        coinScore += amount;
        UpdateCoinScoreText();
    }

    public void UpdateEnemiesRemainingText()
    {
        enemiesRemainingText.text = "Cats remaining: " + enemiesRemaining;
    }

    public void UpdateCoinScoreText()
    {
        coinScoreText.text = "Coins: " + coinScore;
    }

    public void Victory()
    {
        SceneManager.LoadScene("Win");
    }
}
