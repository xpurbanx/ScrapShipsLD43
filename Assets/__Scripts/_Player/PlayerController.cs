﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{

    private Rigidbody2D rigidbody;
    public float movementSpeed = 1f;
    public float rotateSpeed = 100f;
    public float constantSpeed = 1f;
    private float moveDirection;
    private float moveAmount;
    private float rotateAmount;
    private Transform transform;
    private Player player;
    private float moveRotation;

    public float maxHeight = 10f;
    public float maxWidth = 6f;

    string enemyPlayer;
    int damageTaken;

    private PlayerAttack attack;



    private void Start ()
    {
        attack = GetComponent<PlayerAttack>();
        player = GetComponent<Player>();    
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();

        if (tag == "Player1")
            enemyPlayer = "Player2";
        else
            enemyPlayer = "Player1";

        enemyPlayer = enemyPlayer + "Bullet";


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.tag == enemyPlayer)
        {

            damageTaken = collision.collider.GetComponent<Bullet>().damage;// = collision.gameObject.GetComponent<Player>().scrapAmount - damage;
            scrapAmount = scrapAmount - damageTaken;
            //if(goldAmount > 3)
            goldAmount = goldAmount - collision.collider.GetComponent<Bullet>().goldDamage;
            if (goldAmount < 0)
                goldAmount = 0;
            //damageTaken = 0;
            Debug.Log("HIT");
            Debug.Log(scrapAmount);


        }
        //if (collision.gameObject.tag == "Scrap")
        //{
        //    AddScrap();
        //    Debug.Log(scrapAmount);
        //    Destroy(collision.gameObject);
        //}
        //if (collision.gameObject.tag == "Pirate")
        //{
        //    pirateAmount++;
        //    Debug.Log(pirateAmount);
        //    Destroy(collision.gameObject);
        //}
        //if (collision.gameObject.tag == "Gold")
        //{
        //    goldAmount++;
        //    Debug.Log(goldAmount);
        //    Destroy(collision.gameObject);
        //}

    }
    private void FixedUpdate()
    {
        //if (Input.GetKeyDown("f")) 
        //{
        //    attack.Fire("f");
        //    //scrapAmount--;
        //}
        //if (Input.GetKeyDown("h")) 
        //{
        //    attack.Fire("h");
        //    //scrapAmount--;
        //}
        
        Movement();
    }
    private void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        //Debug.Log(Input.GetAxisRaw("Vertical"));
       // if (Input.GetKeyDown("f")) attack.Fire("f");

        
        RestrictPosition();
        if (scrapAmount <= 0)
            Destroy(gameObject);

    }
    private void RestrictPosition()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxWidth, maxWidth), Mathf.Clamp(transform.position.y, -maxHeight, maxHeight), transform.position.z);
    }
    private void Movement()
    {
        //moveDirection = Input.GetAxisRaw("P2_Horizontal");
        moveDirection = player.InputVertical();
        moveAmount = moveDirection * movementSpeed * Time.deltaTime;
        transform.position += transform.up * moveAmount + transform.up * constantSpeed * Time.deltaTime;

        //rigidbody.MovePosition(new Vector2(rigidbody.position + (Vector2.up * moveAmount), rigidbody.position.y ));
        //rigidbody.AddForce(transform.up * moveAmount); //dziala
        //if (rigidbody.velocity.x > 5f) rigidbody.velocity = new Vector2(5f, 0f);
        //if (rigidbody.velocity.y > 5f) rigidbody.velocity = new Vector2(0f, 5f);
        //rigidbody.velocity = new Vector2(rigidbody.;

        //moveRotation = Input.GetAxisRaw("P2_Vertical");w
        moveRotation = player.InputHorizontal();
        rotateAmount = moveRotation * rotateSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0 , -rotateAmount));
        rigidbody.velocity = new Vector2(0f, 0f);
        // rigidbody.MoveRotation(rigidbody.rotation - rotateAmount);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }*/
}
