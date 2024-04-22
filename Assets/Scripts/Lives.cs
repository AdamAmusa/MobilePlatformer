using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{

    private static int lives = 3;
    // Start is called before the first frame update

    public void DecreaseLives(){
        lives--;
    }   

    public int GetLives(){
        return lives;
    }

    
    public void resetLife(){
        lives = 3;
    }

}
