using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D rbody;
    
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(rbody.gameObject);
           
        }
            
    }

    // Update is called once per frame
    void Update () {
		
	}
}
