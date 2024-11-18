using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject death;

    public void TakeDamage(int damage)
    {
      
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
