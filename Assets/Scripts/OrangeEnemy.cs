using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeEnemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject death;
    private Animator animator;


    public void TakeDamage(int damage)
    {
        animator = GetComponent<Animator>();

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        health -= damage;
    }

    private void Die()
    {
        if (death != null)
        {
            // Instantiate(death, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}

