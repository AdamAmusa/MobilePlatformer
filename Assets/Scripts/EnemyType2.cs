using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyType2 : MonoBehaviour
{
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0;
    float shootTimer = 0.0f;
    float delayTimer = 0.0f;

    Vector2 direction = new Vector2(-1, 0);
    public Bullet bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        //direction = new Vector2(-1, 0);
        Debug.Log(direction);
        
      

            if (delayTimer >= shootDelaySeconds)
            {
                //Debug.Log("Fire");
                if (shootTimer >= shootIntervalSeconds)
                {

                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer -= Time.deltaTime;
            }
        
    }


    void Shoot(){
        //Instantiate a bullet
          Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.direction = direction;
}
}
