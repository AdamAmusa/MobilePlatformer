using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    GameObject superAbility;

    PlayerMovement playerMovement;

    Coins coinObject;
    LoadLevels load;
    DestroyedEnemies destroyedEnemies;

    Lives liveObject;
    public AudioManager audioObject;
    // Start is called before the first frame update
    void Start()
    {
        audioObject = GameObject.FindObjectOfType<AudioManager>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        load = GameObject.FindObjectOfType<LoadLevels>();
        destroyedEnemies = GameObject.FindObjectOfType<DestroyedEnemies>();
        superAbility = transform.Find("SuperAbility").gameObject;
        coinObject = GameObject.FindObjectOfType<Coins>();
        disableAbility();
        liveObject = GameObject.FindObjectOfType<Lives>();
    }

    // Update is called once per frame
    void Update()
    {
        checkifAlive();
        Debug.Log(playerMovement.isBoostJumpEnabled());
    }

    //Done on Film *SuperAbility*
    void disableAbility()
    {
        superAbility.SetActive(false);
    }

    //Done on Film *SuperAbility*
    void enableAbility()
    {
        superAbility.SetActive(true);
        Invoke("disableAbility", 10.0f); //disables the ability after 10 seconds
    }


    //function to check if the ability is active
    bool isAbilityActive()
    {
        return superAbility.activeSelf;
    }

    //function to check if the player is alive
    void checkifAlive()
    {
        if (liveObject.GetLives() == 0)
        {
            Destroy(this.gameObject);
            load.reloadLevel();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Check if player collides with enemy
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("Player collided with enemy");
            //if ability is not active, decrease lives
            if (!isAbilityActive())
            {
                liveObject.DecreaseLives();
            }

            Debug.Log("Lives:" + liveObject.GetLives());
        }

        //Done on Film *SuperAbility*
        if (isAbilityActive() && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            destroyedEnemies.addDestroyedEnemies();
            Debug.Log("Ability used");
        }

    //if player collides with bullet
     if (other.gameObject.CompareTag("Bullet"))
        {
            //Done on Film *SuperAbility*
            if (!isAbilityActive())
            {   
                Destroy(other.gameObject);
                //if ability is not active, decrease lives
                liveObject.DecreaseLives();
               Debug.Log("Bullet: takes life");
                
            }
            else{
                //if ability is active, destroy the bullet
                Destroy(other.gameObject);
                
            }
        }
        //if player collides with coin
         if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            audioObject.PlayCollect();
            coinObject.addCoins();


        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SuperAbility"))
        {
            Destroy(other.gameObject);
            enableAbility();//Done on Film *SuperAbility*

        }

        if (other.gameObject.CompareTag("JumpBoosters") && !playerMovement.isBoostJumpEnabled())
        {
            Destroy(other.gameObject);
            playerMovement.boostJump();

        }
       

    }






}
