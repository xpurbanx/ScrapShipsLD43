using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int playerNumber = 1;
    public string inputHorizontal, inputVertical;

    private void Awake()
    {
        
    }
    void Start () {

        if (playerNumber == 1)
        {
            inputHorizontal = "Horizontal1";
            inputVertical = "Vertical1";
        }

        else if (playerNumber == 2)
        {
            inputHorizontal = "Horizontal2";
            inputVertical = "Vertical2";
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
