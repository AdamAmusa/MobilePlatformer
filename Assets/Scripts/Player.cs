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
    // Start is called before the first frame update
    void Start()
    {
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

    void disableAbility()
    {
        superAbility.SetActive(false);
    }

    void enableAbility()
    {
        superAbility.SetActive(true);
        Invoke("disableAbility", 10.0f); //disables the ability after 10 seconds
    }

    bool isAbilityActive()
    {
        return superAbility.activeSelf;
    }

    bool isSuperJumpActive()
    {
        return superAbility.activeSelf;
    }

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
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("Player collided with enemy");
            if (!isAbilityActive())
            {
                liveObject.DecreaseLives();
            }

            Debug.Log("Lives:" + liveObject.GetLives());
        }

        if (isAbilityActive() && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            destroyedEnemies.addDestroyedEnemies();
            Debug.Log("Ability used");
        }


     if (other.gameObject.CompareTag("Bullet"))
        {
            if (!isAbilityActive())
            {   
                Destroy(other.gameObject);
                liveObject.DecreaseLives();
               Debug.Log("Bullet: takes life");
                
            }
            else{
                Destroy(other.gameObject);
                
            }
        }

         if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinObject.addCoins();

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SuperAbility"))
        {
            Destroy(other.gameObject);
            enableAbility();

        }

        if (other.gameObject.CompareTag("JumpBoosters") && !playerMovement.isBoostJumpEnabled())
        {
            Destroy(other.gameObject);
            playerMovement.boostJump();

        }
       

    }






}
