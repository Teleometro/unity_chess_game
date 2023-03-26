using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromotePanelScript : Entity {



    void Update ()
    {
        if (promotedPawnIndex == 100)
        {
            gameObject.SetActive(false);
        }

	}



}
