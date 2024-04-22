using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    DestroyedEnemies destroyedEnemies;
    // Start is called before the first frame update
    void Start()
    {
        destroyedEnemies = GameObject.FindObjectOfType<DestroyedEnemies>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Enemy");
        if (other.gameObject.CompareTag("Enemy"))
        {
            destroyedEnemies.addDestroyedEnemies();
            Destroy(other.gameObject);
        }
    }
}
