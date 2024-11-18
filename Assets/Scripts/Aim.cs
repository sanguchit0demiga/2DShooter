using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Transform aimTransform;
    private Vector3 originalScale;
    private SpriteRenderer rifleRenderer;
    private List<SpriteRenderer> handsRenderers = new List<SpriteRenderer>();

    private void Start()
    {
        
        GameObject Rifle = GameObject.FindGameObjectWithTag("Rifle");
        if (Rifle != null)
        {
            aimTransform = Rifle.transform;
            originalScale = aimTransform.localScale;
            rifleRenderer = Rifle.GetComponent<SpriteRenderer>();
        }

        
        GameObject[] hands = GameObject.FindGameObjectsWithTag("Hands");
        foreach (GameObject hand in hands)
        {
            SpriteRenderer handRenderer = hand.GetComponent<SpriteRenderer>();
            if (handRenderer != null)
            {
                handsRenderers.Add(handRenderer);
            }
        }
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

      
        Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        
        aimTransform.eulerAngles = new Vector3(0, 0, angle - 180);
        Vector3 localScale = originalScale;

       
        if (angle > 90 || angle < -90)
        {
            localScale.y = Mathf.Abs(originalScale.y); 
        }
        else
        {
            localScale.y = -Mathf.Abs(originalScale.y);  
        }
        aimTransform.localScale = localScale;

       
        if (Input.GetKey(KeyCode.W))
        {
            
            rifleRenderer.sortingOrder = 1;  
            foreach (SpriteRenderer handRenderer in handsRenderers)
            {
                handRenderer.sortingOrder = 1; 
            }
        }
        else
        {
           
            rifleRenderer.sortingOrder = 3;  
            foreach (SpriteRenderer handRenderer in handsRenderers)
            {
                handRenderer.sortingOrder = 2; 
            }
        }
    }
}
