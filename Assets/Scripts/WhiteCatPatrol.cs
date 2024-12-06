using System.Collections;
using UnityEngine;

public class WhiteCatPatrol : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject DieEffect;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private Transform[] waypoints;

    private int currentWaypoint = 0;
    private bool isWaiting = false;
    private SpriteRenderer spriteRenderer;
    private float health;
    public static int enemiesKilled = 0;

    public void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, health);
        spriteRenderer = GetComponent<SpriteRenderer>();


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

    void Update()
    {
        if (!isWaiting)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypoint++;
        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }

        Flip();
        isWaiting = false;
    }

    private void Flip()
    {
        if (transform.position.x > waypoints[currentWaypoint].position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}