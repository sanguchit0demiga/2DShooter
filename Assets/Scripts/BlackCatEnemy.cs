using System.Collections;
using UnityEngine;
using UnityEngine.UI; 

public class BlackCatEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject DieEffect;
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthBar; 

    private float health;
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;

    private void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

       
        if (healthBar != null)
        {
            healthBar.fillAmount = 1f;
        }
    }

    void Update()
    {
        Follow();
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(GetDamage(damage));
    }

    IEnumerator GetDamage(float damage)
    {
        health -= damage;


        if (healthBar != null)
        {
            healthBar.fillAmount = health / maxHealth; 
        }

        
        if (health > 0f)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
        }
        else
        {
           
            Instantiate(DieEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void Follow()
    {
        if (Vector2.Distance(transform.position, player.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            Attack();
        }

        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }

    private void Attack()
    {
        
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}

