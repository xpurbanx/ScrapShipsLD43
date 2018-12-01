using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPirateDisplay : MonoBehaviour {

    Text text;
    public Player player;

    private void Awake()
    {
        text = GetComponent<Text>();       
    }

    // Update is called once per frame
    void Update ()
    {
       
        text.text = "Pirates: " + player.pirateAmount.ToString();
        

    }
}
