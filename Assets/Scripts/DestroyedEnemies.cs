using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedEnemies : MonoBehaviour
{

    private static int destroyedEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //function to add destroyed enemies
   public void addDestroyedEnemies(){
        Debug.Log("Destroyed Enemies added");
        destroyedEnemies++;
    }

    //function to get destroyed enemies
    public int getDestroyedEnemies(){
        return destroyedEnemies;
    }

    //function to reset destroyed enemies
    public void resetDestroyedEnemies(){
        destroyedEnemies = 0;
    }
}
