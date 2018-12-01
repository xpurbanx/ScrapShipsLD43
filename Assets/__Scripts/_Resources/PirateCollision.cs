using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateCollision : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pirate")
        {
            Destroy(collision.gameObject);
        }
    }

}
