using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LoadLevels : MonoBehaviour
{

    Lives life;
    Coins coinObject;
    DestroyedEnemies destroyedObject;
        // Start is called before the first frame update
    void Start()
    {
        life = GameObject.FindObjectOfType<Lives>();
        coinObject = GameObject.FindObjectOfType<Coins>();
        destroyedObject = GameObject.FindObjectOfType<DestroyedEnemies>();
    }

 

    public void reloadLevel(){
        life.resetLife();
        coinObject.resetCoins();
        destroyedObject.resetDestroyedEnemies();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadNextLevel(){
        life.resetLife();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   
}
