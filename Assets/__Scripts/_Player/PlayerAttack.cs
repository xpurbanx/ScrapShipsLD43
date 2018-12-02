using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player {

    public GameObject scrapBullet1, pirateBullet, goldBullet;
    public SpriteRenderer ammoSprite;
   
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
    public string changeAmmo;
    bool ammoCoroutineStarted = false;


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

        ammo = scrapBullet1;
        ammoSprite.sprite = ammo.GetComponent<SpriteRenderer>().sprite;
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

       // if (Input.GetButton(changeAmmo))
       if(Input.GetButton(changeAmmo) && !ammoCoroutineStarted)
        {
            StartCoroutine("ChangeAmmo");
            Debug.Log("Coroutine Launching");
            ammoCoroutineStarted = true;
        }
            
        

    }
    private IEnumerator ChangeAmmo()
    {
        if (Input.GetButton(changeAmmo))
        {
            Debug.Log("Coroutine Started");
            if (ammo == scrapBullet1)
            {
                ammo = pirateBullet;
                ammoSprite.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            }
                
            else if (ammo == pirateBullet)
            {
                ammoSprite.transform.localScale = new Vector3(2f, 2f, 1);
                ammo = goldBullet;
            }
                
            else if (ammo == goldBullet)
                ammo = scrapBullet1;

            ammoSprite.sprite = ammo.GetComponent<SpriteRenderer>().sprite;
            yield return new WaitForSeconds(1f);
            ammoCoroutineStarted = false;
        }
            
            
        
    }

    public void Fire()
    {
        
            //ammo = scrapBullet1;
        
            
        
            GameObject Bullet;
            Bullet = (Instantiate(ammo, spawn.transform.position, Quaternion.Euler(new Vector2(1, 0)))) as GameObject;
            Debug.Log("Bullet is found");


            //add force to the spawned objected
            Bullet.GetComponent<Rigidbody2D>().AddForce(shootDir * transform.right * speed, ForceMode2D.Impulse);
            lastBulletTime = Time.time;

            Debug.Log("Force is added");
        

        
        
    }
}
