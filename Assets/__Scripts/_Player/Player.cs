using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int scrapAmount = 0;
    public int goldAmount = 0;
    public int pirateAmount = 0;

    public int playerNumber = 1;
    private float inputHorizontal, inputVertical;



    public float InputHorizontal()
    {
        if (playerNumber == 1)
            return Input.GetAxisRaw("P1_Horizontal");


        else
            return Input.GetAxisRaw("P2_Horizontal");

    }
    public float InputVertical()
    {
        if (playerNumber == 1)
            return Input.GetAxisRaw("P1_Vertical");


        else
            return Input.GetAxisRaw("P2_Vertical");

    }
    void Start()
    {
        pirateAmount = 0;
        goldAmount = 0;
        scrapAmount = 0;

    }

        
    }

        

