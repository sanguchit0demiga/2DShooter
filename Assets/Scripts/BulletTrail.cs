using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    public Transform shootPoint;
    public float distance = 10f;
    public LayerMask targetLayer;
    public LineRenderer lineRenderer;


    private void Update()
    {
      

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

   private void Shoot()
    {
        Vector3 mousePosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector2 direction = (mousePosition- shootPoint.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, direction, distance, targetLayer);
        lineRenderer.SetPosition(0, shootPoint.position);

        if (hit)
        {
           
            if (hit.collider.CompareTag("Enemy"))
            {
                WhiteCatPatrol enemy3 = hit.collider.GetComponent<WhiteCatPatrol>();
                OrangeEnemy enemy2 = hit.collider.GetComponent<OrangeEnemy>();
                BlackCatEnemy enemy = hit.collider.GetComponent<BlackCatEnemy>();
                if (enemy != null)
                {
                  enemy.TakeDamage(1);
                }
                if (enemy2 != null)
                {
                    enemy2.TakeDamage(1);
                }
                if (enemy3 != null)
                {
                    enemy3.TakeDamage(1);
                }
            }

         
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            
            lineRenderer.SetPosition(1, (Vector2)shootPoint.position + direction * distance);
        }

        
        StartCoroutine(ShowLaser());

        IEnumerator ShowLaser()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        lineRenderer.enabled = false;
    }
    }
}

