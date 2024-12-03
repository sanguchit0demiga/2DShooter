using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Transform player;
    private Rigidbody2D rb;
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
    void Update()
    {
        
    }
}
