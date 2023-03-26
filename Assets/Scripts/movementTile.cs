using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTile : Entity {

	// Use this for initialization
	void Start () {
        if (this.transform.position.x > 8 || this.transform.position.x < 0 || this.transform.position.y > 8 || this.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    
}
