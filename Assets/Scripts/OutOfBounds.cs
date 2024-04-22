using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    LoadLevels loadLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void OnTriggerEnter2D(Collider2D other)
{
    if(other.gameObject.tag == "Player"){
        loadLevel = GameObject.FindObjectOfType<LoadLevels>();
        loadLevel.reloadLevel();
    }   
}
}