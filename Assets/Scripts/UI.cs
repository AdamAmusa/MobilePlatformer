using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    Coins coinObject;
    Lives liveObject;

    DestroyedEnemies destroyedObject;

    public TextMeshProUGUI lifeText, coinText, destroyedText;
    // Start is called before the first frame update
    void Start()
    {
        coinObject = GameObject.FindObjectOfType<Coins>();
        liveObject = GameObject.FindObjectOfType<Lives>();
        destroyedObject = GameObject.FindObjectOfType<DestroyedEnemies>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Lives: " + liveObject.GetLives();
        coinText.text = "Coins: " + coinObject.getCoins();
        destroyedText.text = "Destroyed: " + destroyedObject.getDestroyedEnemies();
    }
}
