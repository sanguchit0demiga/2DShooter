using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] private float speed; 
    private Transform player; 
    private Rigidbody2D rb; 
    public float daño = 10f; 

    void Start()
    {
       
        player = FindObjectOfType<Moveplayer>().transform;
        rb = GetComponent<Rigidbody2D>();
        LaunchProjectile();
        Destroy(gameObject, 3f); 
    }

    private void LaunchProjectile()
    {
        
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rb.velocity = directionToPlayer * speed;  
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
           
            Moveplayer jugador = other.GetComponent<Moveplayer>();
            if (jugador != null)
            {
                jugador.TakeDamage(daño); 
            }
            Destroy(gameObject); 
        }
    }
}
