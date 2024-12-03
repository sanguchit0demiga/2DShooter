using System.Collections;
using UnityEngine;

public class WhiteCatPatrol : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private Transform[] waypoints;

    private int currentWaypoint = 0;
    private bool isWaiting = false;

    void Update()
    {
        if (!isWaiting) 
        {
            Patrol();
        }
    }

    private void Patrol()
    {
    
        if (transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else
        {

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypoint++;
        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }

       
        Flip();
        isWaiting = false;
    }

    private void Flip()
    {
        
        if (transform.position.x > waypoints[currentWaypoint].position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}