using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player {

    public GameObject scrapBullet1;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public float speed = 1f;
    private GameObject ammo;
    private Transform spawn;
    private float shootDir;
    public float cooldown = 0.5f;
    private float lastBulletTime;

    public string fireLeft;
    public string fireRight;


    // Use this for initialization
    private void Awake()
    {
        //if (playerNumber == 1)
        //{
        //    left = Input.GetAxis("Fire1LEFT");
        //    right = Input.GetAxis("Fire1RIGHT");
        //}
        //else
        //{
        //    left = Input.GetAxis("Fire2LEFT");
        //    right = Input.GetAxis("Fire2RIGHT");
        //}
    }
    void Start () {
		
        
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(fireLeft) || Input.GetKeyDown(fireRight))
        if (Time.time > lastBulletTime + cooldown)
        {
            if (Input.GetButton(fireLeft))
            {
                spawn = bulletSpawn1;
                shootDir = -1;
                Fire();
            }

            else if (Input.GetButton(fireRight))
            {
                spawn = bulletSpawn2;
                shootDir = 1;
                Fire();
            }
        }

    }

    public void Fire()
    {
        
            ammo = scrapBullet1;
        
            
        
            GameObject Bullet;
            Bullet = (Instantiate(ammo, spawn.transform.position, Quaternion.Euler(new Vector2(1, 0)))) as GameObject;
            Debug.Log("Bullet is found");


            //add force to the spawned objected
            Bullet.GetComponent<Rigidbody2D>().AddForce(shootDir * transform.right * speed, ForceMode2D.Impulse);
            lastBulletTime = Time.time;

            Debug.Log("Force is added");
        

        
        
    }
}
