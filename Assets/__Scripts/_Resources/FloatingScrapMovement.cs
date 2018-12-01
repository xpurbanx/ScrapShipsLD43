using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScrapMovement : MonoBehaviour {

    public Transform prefab;
    public GameObject gameObjectWhenUseless;
    public float scrapSpeed = 1f;

	void Start ()
    {
        prefab = GetComponent<Transform>();
	}
	
	
	void FixedUpdate ()
    {
        if (prefab.position.y < 6)
            prefab.position -= new Vector3(0, Time.deltaTime*scrapSpeed, 0);
        if (prefab.position.y < - 10)
            Destroy(gameObjectWhenUseless);

    }

    
        
    
}
