using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI damageText;

    Coins coinObject;
    DestroyedEnemies destroyObject;
    
    // Start is called before the first frame update
    void Start()
    {
        coinObject = FindObjectOfType<Coins>();
        destroyObject = FindObjectOfType<DestroyedEnemies>();
        coinText.text = "Coins Collected: " + coinObject.getCoins().ToString();
        damageText.text = "Enemies Destroyed: " + destroyObject.getDestroyedEnemies().ToString();
    }

   
}
