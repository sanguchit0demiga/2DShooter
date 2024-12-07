using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Moveplayer player = other.GetComponent<Moveplayer>();

            if (player != null)
            {
                player.GanarVida(1f);  
            }

            Destroy(gameObject); 
        }
    }
}