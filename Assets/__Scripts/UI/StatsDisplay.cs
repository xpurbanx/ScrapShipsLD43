using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour {

    Text text;
    public Player player;

    private void Awake()
    {
        text = GetComponent<Text>();       
    }

    // Update is called once per frame
    void Update ()
    {
       
        text.text = player.scrapAmount.ToString();
        
	}
}
