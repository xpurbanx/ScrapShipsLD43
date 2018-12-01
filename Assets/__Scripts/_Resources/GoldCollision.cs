using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollision : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            player.goldAmount++;
            Debug.Log(player.goldAmount);
            Destroy(collision.gameObject);
        }
    }

}
