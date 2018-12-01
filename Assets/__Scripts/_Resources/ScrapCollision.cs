using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapCollision : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Scrap")
        {
            Destroy(collision.gameObject);
        }
    }

}
