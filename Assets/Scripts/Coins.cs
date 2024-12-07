using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
           
            LootBag lootBag = FindObjectOfType<LootBag>();

            if (lootBag != null)
            {
                lootBag.CollectCoin(gameObject);  
            }
        }
    }
}