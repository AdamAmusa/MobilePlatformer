using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    private static int coins = 0;
    // Start is called before the first frame update

    public void addCoins(){
        Debug.Log("Coins added");
        coins++;
    }

    public int getCoins(){
        return coins;
    }

    public void resetCoins(){
        coins = 0;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
        Collider2D coinCollider = GetComponent<Collider2D>();

        Collider2D enemyCollider = other.gameObject.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(coinCollider, enemyCollider);
        }

        
    }   
    
}
