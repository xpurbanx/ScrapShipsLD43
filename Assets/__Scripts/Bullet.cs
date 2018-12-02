using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D rbody;
    public float lifeTime = 2.0f;
    public float speed = 1f;
    public int damage = 30;
    public int goldDamage = 5;
    private float spawnTime;
    public string shooterTag;
    string enemyPlayer;

    public int costScrap = 1;
    public int costPirate = 1;
    public int costGold = 1;
    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        spawnTime = Time.time;
        if (tag == "Player1Bullet")
            enemyPlayer = "Player2";
        else
            enemyPlayer = "Player1";

	}

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyPlayer)
        {
            Destroy(rbody.gameObject);
           // collision.gameObject.GetComponent<Player>().scrapAmount = collision.gameObject.GetComponent<Player>().scrapAmount - damage;

            
           
        }
            
    }

    // Update is called once per frame
    void Update () {
		if(Time.time > spawnTime + lifeTime)
            Destroy(rbody.gameObject);

    }
}
