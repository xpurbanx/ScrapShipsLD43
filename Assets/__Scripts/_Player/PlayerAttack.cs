using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject scrapBullet1;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public float speed = 0.1f;
    private GameObject ammo;
    private Transform spawn;
    private float shootDir;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey("Fire11"))
        //{
           
        //}
    }

    public void Fire(string direction)
    {
        ammo = scrapBullet1;
        if (direction == "f")
        {
            spawn = bulletSpawn1;
            shootDir = -1;
        }
            
        else if (direction == "h")
        {
            spawn = bulletSpawn2;
            shootDir = -1;
        }
            

        GameObject Bullet;
        Bullet = (Instantiate(ammo, spawn.transform.position, Quaternion.Euler(new Vector2(shootDir, 0)))) as GameObject;
        Debug.Log("Bullet is found");


        //add force to the spawned objected
        Bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * speed, ForceMode2D.Impulse);

        Debug.Log("Force is added");
    }
}
