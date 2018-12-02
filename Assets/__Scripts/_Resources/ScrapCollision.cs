using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapCollision : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Scrap")
        {
            player.scrapAmount++;
            //Debug.Log(player.scrapAmount);
            Destroy(collision.gameObject);
        }
    }

}
