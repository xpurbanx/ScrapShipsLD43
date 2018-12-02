using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommon : MonoBehaviour {
    public static PlayerCommon Instance;


    public Sprite alert1, alert2, alert3;
    // Use this for initialization
    void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
