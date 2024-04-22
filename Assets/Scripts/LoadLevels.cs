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

 
    //function to reload the level
    public void reloadLevel(){
        life.resetLife();
        coinObject.resetCoins();
        destroyedObject.resetDestroyedEnemies();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //function to start the game
    public void startGame(){
        life.resetLife();
        coinObject.resetCoins();
        destroyedObject.resetDestroyedEnemies();
        SceneManager.LoadScene(0);
    }
    //function to quit the game
    public void quitGame(){
        Application.Quit();
    }

    //function to load the next level
    public void loadNextLevel(){
        life.resetLife();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   



    //function to load the menu
    public void loadMenu(){
        life.resetLife();
        coinObject.resetCoins();
        destroyedObject.resetDestroyedEnemies();
        SceneManager.LoadScene(4);
    }
}
