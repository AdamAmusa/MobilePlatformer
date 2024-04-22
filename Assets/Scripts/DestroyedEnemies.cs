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

   public void addDestroyedEnemies(){
        Debug.Log("Destroyed Enemies added");
        destroyedEnemies++;
    }

    public int getDestroyedEnemies(){
        return destroyedEnemies;
    }

    public void resetDestroyedEnemies(){
        destroyedEnemies = 0;
    }
}
