using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigibody;
    public float movementSpeed = 0.1f;

	void Start ()
    {
        rigibody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rigibody.MovePosition(new Vector2(rigibody.transform.position.x, rigibody.transform.position.y + 1*movementSpeed));


        if (Input.GetKey(KeyCode.DownArrow))
            rigibody.MovePosition(new Vector2(rigibody.transform.position.x, rigibody.transform.position.y + -1*movementSpeed));


        if (Input.GetKey(KeyCode.LeftArrow))
            rigibody.MovePosition(new Vector2(rigibody.transform.position.x - 1*movementSpeed, rigibody.transform.position.y));


        if (Input.GetKey(KeyCode.RightArrow))
            rigibody.MovePosition(new Vector2(rigibody.transform.position.x + 1*movementSpeed, rigibody.transform.position.y));

    }
}
