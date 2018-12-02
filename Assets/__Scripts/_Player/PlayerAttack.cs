using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player {

    public GameObject scrapBullet1, pirateBullet, goldBullet;
    PlayerController playerController;
    public SpriteRenderer ammoSprite;
    private PlayerCommon playerCommon;
    public Sprite alert1, alert2, alert3;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public SpriteRenderer alertPointLeft, alertPointRight;
    //public float speed = 1f;
    private GameObject ammo;
    private Transform spawn;
    private float shootDir;
    public float cooldown = 0.5f;
    private float lastBulletTime;
    public float timeForCharge = .75f;
    public float chargeModifier = .75f;
    private float chargeStage = 0f;
    private float shootTime;
    string fireLeft;
    string fireRight;
    string changeAmmo;
    bool ammoCoroutineStarted = false;
    private int costShoot;
    private int cost;


    // Use this for initialization
    private void Awake()
    {
        if(playerNumber == 1)
        {
            fireLeft = "Fire1LEFT";
            fireRight = "Fire1RIGHT";
            changeAmmo = "ChangeAmmo1";
            playerTag = "Player1";
        }
        if (playerNumber == 2)
        {
            fireLeft = "Fire2LEFT";
            fireRight = "Fire2RIGHT";
            changeAmmo = "ChangeAmmo2";
            playerTag = "Player2";
        }

    }
    void Start () {
        playerController = GetComponent<PlayerController>();
        ammo = scrapBullet1;
        cost = playerController.scrapAmount;
        costShoot = ammo.GetComponent<Bullet>().costScrap;
        ammoSprite.sprite = ammo.GetComponent<SpriteRenderer>().sprite;
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(fireLeft) || Input.GetKeyDown(fireRight))
        if ((Time.time > lastBulletTime + cooldown) && cost >= costShoot)
        {
            
            if (Input.GetButtonDown(fireLeft))
            {
                Debug.Log("FireLeftDown");
                spawn = bulletSpawn1;
                shootDir = -1;
                shootTime = Time.time;
                StartCoroutine("ChargeShot");     
            }

            if (Input.GetButtonUp(fireLeft))
            {
                Debug.Log("FireLeftUp");
                Fire();
                alertPointLeft.sprite = null;
            }

            else if (Input.GetButtonDown(fireRight))
            {
                Debug.Log("FireRightDown");
                spawn = bulletSpawn2;
                shootDir = 1;
                shootTime = Time.time;
                StartCoroutine("ChargeShot");


            }
            if (Input.GetButtonUp(fireRight))
            {
                Debug.Log("FireRightUp");
                Fire();
                alertPointRight.sprite = null;
            }
            
        }

       // if (Input.GetButton(changeAmmo))
       if(Input.GetButton(changeAmmo) && !ammoCoroutineStarted)
        {
            StartCoroutine("ChangeAmmo");
            Debug.Log("Coroutine Launching");
            ammoCoroutineStarted = true;
        }

        ChangeCost();


    }

    private void ChangeCost()
    {
        if (ammo == pirateBullet)
        {
            costShoot = ammo.GetComponent<Bullet>().costPirate;
            cost = playerController.pirateAmount;
           
        }

        else if (ammo == goldBullet)
        {
            
            cost = playerController.goldAmount;
            costShoot = ammo.GetComponent<Bullet>().costGold;
        }

        else if (ammo == scrapBullet1)
        {
            
            cost = playerController.scrapAmount;
            costShoot = ammo.GetComponent<Bullet>().costScrap;
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
               // costShoot = ammo.GetComponent<Bullet>().costPirate;
               // cost = playerController.pirateAmount;
                ammoSprite.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            }
                
            else if (ammo == pirateBullet)
            {
                ammoSprite.transform.localScale = new Vector3(2f, 2f, 1);
                ammo = goldBullet;
                //cost = playerController.goldAmount;
                //costShoot = ammo.GetComponent<Bullet>().costGold;
            }
                
            else if (ammo == goldBullet)
            {
                ammo = scrapBullet1;
               // cost = playerController.scrapAmount;
               // costShoot = ammo.GetComponent<Bullet>().costScrap;
            }
                

            ammoSprite.sprite = ammo.GetComponent<SpriteRenderer>().sprite;
            yield return new WaitForSeconds(1f);
            ammoCoroutineStarted = false;
        }

    }
    private IEnumerator ChargeShot()
    {
        
                while ((Input.GetButton(fireLeft) || Input.GetButton(fireRight)) && chargeStage < 3)
                {
                    chargeStage++;
                    if (shootDir == -1)
                        changeAlert(chargeStage, alertPointLeft);
                    if (shootDir == 1)
                        changeAlert(chargeStage, alertPointRight);
                     Debug.Log("ChargeStage: " + chargeStage);
                    yield return new WaitForSeconds(timeForCharge);
                 }


    }
    private void changeAlert(float stage, SpriteRenderer alert)
    {
        if (stage == 0)
            alert.sprite = null;
        else if (stage == 1)
            alert.sprite = alert1;
        else if (stage == 2)
            alert.sprite = alert2;
        else if (stage == 3)
            alert.sprite = alert3;
        
    }

   
    public void Fire()
    {
        float shootForce;
            
        
        GameObject Bullet;
        Bullet = (Instantiate(ammo, spawn.transform.position, Quaternion.Euler(new Vector2(1, 0)))) as GameObject;
        // Debug.Log("Bullet is found");
        Bullet.tag = playerTag+"Bullet";
        shootForce = shootDir * ammo.GetComponent<Bullet>().speed * (chargeModifier * (1 + chargeStage));

        //add force to the spawned objected
        // Bullet.GetComponent<Rigidbody2D>().AddForce(shootDir * transform.right * ammo.GetComponent<Bullet>().speed, ForceMode2D.Impulse);
        Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * shootForce, ForceMode2D.Impulse);
        chargeStage = 0;
        if (ammo == scrapBullet1)
        {
            playerController.scrapAmount = playerController.scrapAmount - costShoot;
        }
        else if (ammo == pirateBullet)
        {
            playerController.pirateAmount = playerController.pirateAmount - costShoot;
        }
        else if (ammo == goldBullet)
        {
            playerController.goldAmount = playerController.goldAmount - costShoot;
        }

        lastBulletTime = Time.time;

       // Debug.Log("Force is added");
        

        
        
    }
}
