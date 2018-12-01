using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollision : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            Destroy(collision.gameObject);
        }
    }

}
