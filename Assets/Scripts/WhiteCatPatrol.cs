using System.Collections;
using UnityEngine;

public class WhiteCatPatrol : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject DieEffect;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private string waypointTag = "Waypoint";

    private Transform[] waypoints;
    private int currentWaypoint = 0;
    private bool isWaiting = false;
    private SpriteRenderer spriteRenderer;
    private float health;

    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, health);
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(waypointTag);
        waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }

        float minDistance = Mathf.Infinity;
        for (int i = 0; i < waypoints.Length; i++)
        {
            float distance = Vector2.Distance(transform.position, waypoints[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                currentWaypoint = i;
            }
        }
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
            GameObject effectInstance = Instantiate(DieEffect, transform.position, Quaternion.identity);
            Destroy(effectInstance, 0.5f);

            GameController.EnemyKilled();
            GetComponent<LootBag>().InstantiateLoot(transform.position);
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
