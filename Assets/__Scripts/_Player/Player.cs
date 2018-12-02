using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Player1, Player2;

    public int scrapAmount = 0;
    public int goldAmount = 0;
    public int pirateAmount = 0;
    [SerializeField]
    protected string playerTag;
    
    public int playerNumber = 1;
    private float inputHorizontal, inputVertical;

    private void OnEnable()
    {
        //if (Player1 == null) Player1 = this;
        //else Player2 = this;
        if (tag == "Player1") Player1 = this;
        else Player2 = this;
    }


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
        
        

    }
   
    
   
    private void Update()
    {
        
        //Debug.Log(scrapAmount);
    }

    public void AddScrap()
    {
        scrapAmount++;
    }
    public void AddPirate()
    {
        pirateAmount++;
    }
    public void AddGold()
    {
        goldAmount++;
    }
}

        

