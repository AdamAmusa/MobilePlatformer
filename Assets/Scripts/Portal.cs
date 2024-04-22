using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    LoadLevels loadLevel;   
    // Start is called before the first frame update
    void Start()
    {
        loadLevel = GameObject.FindObjectOfType<LoadLevels>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       loadLevel.loadNextLevel();
    }
}
