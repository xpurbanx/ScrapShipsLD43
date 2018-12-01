using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D rbody;
    public float lifeTime = 2.0f;
    private float spawnTime;
    
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        spawnTime = Time.time;

	}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Destroy(rbody.gameObject);
           
    //    }
            
    //}

    // Update is called once per frame
    void Update () {
		if(Time.time > spawnTime + lifeTime)
            Destroy(rbody.gameObject);

    }
}
