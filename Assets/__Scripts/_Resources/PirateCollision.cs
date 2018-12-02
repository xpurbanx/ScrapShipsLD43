using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateCollision : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pirate")
        {
            player.pirateAmount++;
            Debug.Log(player.pirateAmount);
            Destroy(collision.gameObject);
        }
    }

}
