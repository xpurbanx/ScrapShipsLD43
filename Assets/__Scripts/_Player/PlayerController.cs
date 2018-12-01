using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{

    private Rigidbody2D rigibody;
    public float movementSpeed = 10f;
    public float rotateSpeed = 100f;
    private float moveDirection;
    private float moveAmount;
    private float rotateAmount;
    private Transform transform;
    private Player player;
    //private float inputHorizontal, inputVertical;
    private float moveRotation;
    // int playerNumber = 1;

	private void Start ()
    {
        player = GetComponent<Player>();    
        rigibody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();

        
    }

    private void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        //Debug.Log(Input.GetAxisRaw("Vertical"));
        Movement();

    }
    private void Movement()
    {
        //moveDirection = Input.GetAxisRaw("P2_Horizontal");
        moveDirection = player.InputVertical();
        moveAmount = moveDirection * movementSpeed * Time.deltaTime;
        transform.position += transform.up * moveAmount;
     


        //moveRotation = Input.GetAxisRaw("P2_Vertical");
        moveRotation = player.InputHorizontal();
        rotateAmount = moveRotation * rotateSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0 , -rotateAmount));
    }
}
