﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanelScript : Entity {

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (endGame == false)
        {
            gameObject.SetActive(false);
        }
	}
}
