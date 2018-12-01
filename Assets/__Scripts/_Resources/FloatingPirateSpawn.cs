using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPirateSpawn : MonoBehaviour {

    public GameObject prefab;
    private float lastSpawn = 0;
    public float cooldownTime = 5;
		
	void Update ()
    {
        if (Time.time >= lastSpawn + cooldownTime)
        {
            Instantiate(prefab, new Vector2(Random.Range(-9, 5), 9.9f), Quaternion.identity);
            lastSpawn = Time.time;
        }
          
    }
}
