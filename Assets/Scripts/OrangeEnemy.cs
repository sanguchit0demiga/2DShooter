using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrangeEnemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float timeBetweenShoots;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject DieEffect;
    [SerializeField] private TMP_Text enemiesKilledText;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float health;

    public static int enemiesKilled = 0;
    public void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, health);
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Shoot());
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(GetDamage(damage));
      
    }

    IEnumerator GetDamage(float damage)
    {
        float damageDuration = 0.1f;
        health -= damage;
        healthBar.UpdateHealthBar(maxHealth, health);


        if (health > 0f)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(damageDuration);
            spriteRenderer.color = Color.white;
        }
        else
        {
            Instantiate(DieEffect, transform.position, Quaternion.identity);
            GameController.EnemyKilled();
            Destroy(gameObject);
        }
    }
   
   IEnumerator Shoot()
    {
        while (true) {
        yield return new WaitForSeconds(timeBetweenShoots);
        Instantiate(projectilePrefab, transform.position,Quaternion.identity);
    }

    }
    void UpdateEnemiesKilledText()
    {
        enemiesKilledText.text = "Cats killed: " + enemiesKilled;
    }
}

