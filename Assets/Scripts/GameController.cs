using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TMP_Text enemiesKilledText;
    private static int enemiesKilled = 0;
    public int enemiesToWin = 20;

    public TMP_Text coinScoreText;
    private static int coinScore = 0;

  
    [SerializeField] private float playerHealth = 100f;
    [SerializeField] private float maxHealth = 100f;

    void Start()
    {
        UpdateEnemiesKilledText();
        UpdateCoinScoreText();
    }

   
    public void IncreasePlayerHealth(float amount)
    {
        playerHealth += amount;

       
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        Debug.Log("Player Health: " + playerHealth);
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

    public void IncreaseCoinScore(int amount)
    {
        coinScore += amount;
        UpdateCoinScoreText();
    }

    public void UpdateEnemiesKilledText()
    {
        enemiesKilledText.text = "Cats killed: " + enemiesKilled;
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
