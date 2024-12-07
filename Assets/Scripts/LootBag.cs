using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject Heart;
    public GameObject Coin;
    public List<Loot> lootList = new List<Loot>();


    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();

        foreach (Loot item in lootList)
        {

            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }

        }
        if (possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;

        }
        return null;

    }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();  

        if (droppedItem != null)
        {
            GameObject lootGameObject = null;

            if (droppedItem.lootName == "Coin")
            {
                lootGameObject = Instantiate(Coin, spawnPosition, Quaternion.identity);
                lootGameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);  
            }
            else if (droppedItem.lootName == "Heart")
            {
                lootGameObject = Instantiate(Heart, spawnPosition, Quaternion.identity);
                lootGameObject.transform.localScale = new Vector3(2f, 2f, 2f); 
            }

            if (lootGameObject != null)
            {
                lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            }
        }
    }

    public void CollectCoin(GameObject coin)
    {
        Destroy(coin);
        GameController gameController = FindObjectOfType<GameController>(); 
        if (gameController != null)
        {
            gameController.IncreaseCoinScore(1);

        }
    }
}
