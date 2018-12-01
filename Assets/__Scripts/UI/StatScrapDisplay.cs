using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScrapDisplay : MonoBehaviour {

    Text text;
    public Player player;

    private void Awake()
    {
        text = GetComponent<Text>();       
    }

    // Update is called once per frame
    void Update ()
    {
       
        text.text = "Scrap: " + player.scrapAmount.ToString();
        

    }
}
