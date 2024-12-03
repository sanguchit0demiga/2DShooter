using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeEnemy : MonoBehaviour
{
    [SerializeField] private float timeBetweenShoots;
    [SerializeField] private GameObject projectilePrefab;
    private Animator animator;


    public void Start()
    {
        StartCoroutine(Shoot());
    }

   IEnumerator Shoot()
    {
        while (true) {
        yield return new WaitForSeconds(timeBetweenShoots);
        Instantiate(projectilePrefab, transform.position,Quaternion.identity);
    }
    }
}
