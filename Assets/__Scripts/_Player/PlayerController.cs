using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player {

    private Rigidbody2D rigibody;
    public float movementSpeed = 10f;
    public float rotateSpeed = 100f;
    private float moveDirection;
    private float moveAmount;
    private float rotateAmount;
    private Transform transform;
    private Player player;

    private float moveRotation;
    

	void Start ()
    {
        player.GetComponent<Player>();
        rigibody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
	}

    private void Update()
    {

        Movement();

    }
    // Update is called once per frame
    //void FixedUpdate ()
    //{
    //    if (Input.GetAxisRaw("Vertical"))
    //        rigibody.MovePosition(new Vector2(rigibody.transform.position.x, rigibody.transform.position.y + 1*movementSpeed));


    //    if (Input.GetKey(KeyCode.DownArrow))
    //        rigibody.MovePosition(new Vector2(rigibody.transform.position.x, rigibody.transform.position.y + -1*movementSpeed));


    //    if (Input.GetKey(KeyCode.LeftArrow))
    //        rigibody.MovePosition(new Vector2(rigibody.transform.position.x - 1*movementSpeed, rigibody.transform.position.y));


    //    if (Input.GetKey(KeyCode.RightArrow))
    //        rigibody.MovePosition(new Vector2(rigibody.transform.position.x + 1*movementSpeed, rigibody.transform.position.y));

    //}
    private void Movement()
    {
        moveDirection = Input.GetAxisRaw(player.inputHorizontal);
        moveAmount = moveDirection * movementSpeed * Time.deltaTime;
        transform.position += transform.up * moveAmount;

        moveRotation = Input.GetAxisRaw(player.inputVertical);
        rotateAmount = moveRotation * rotateSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0 , -rotateAmount));
    }
}
