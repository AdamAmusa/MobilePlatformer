using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;

    private Transform currentPoint;

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }




    void Patrol(){
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform){
            rb.velocity = new Vector2(speed,0); //Move right
        }
        else{
            rb.velocity = new Vector2(-speed,0); //Move left
        }
        
        //Change direction
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform){
            currentPoint = pointA.transform;
        }
        //Change direction
        else if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform){
            currentPoint = pointB.transform;
        }
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }   

}
