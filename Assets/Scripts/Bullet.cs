using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(-1,0);

    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 14f);
        
    }




    void FixedUpdate()
{
    Vector2 pos = transform.position;

    pos += velocity * Time.fixedDeltaTime;  
    

    transform.position = pos;

}
public void OnCollisionEnter2D(Collision2D other)
{
    if(other.gameObject.tag == "Enemy")
    {   
        Collider2D bulletCollider = GetComponent<Collider2D>();

        Collider2D enemyCollider = other.gameObject.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(bulletCollider, enemyCollider);

    }

}

}
