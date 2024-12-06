using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemyController : MonoBehaviour
{

    private float minX,maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float enemiestime;

    private float TimeNextEnemy;
   private void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y) ;
    }

    private void Update()
    {
        TimeNextEnemy += Time.deltaTime;
        if (TimeNextEnemy >= enemiestime)
        {
            TimeNextEnemy = 0;
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        int enemyNumber = Random.Range (0, enemies.Length);
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemies[enemyNumber], randomPosition, Quaternion.identity);
    }
}