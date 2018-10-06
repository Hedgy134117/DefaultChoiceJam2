using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLighter : MonoBehaviour {

    public bool isLighting;

	// Update is called once per frame
	void Update () {
        if(Input.GetKey("e")) //Why K ?! xD
        {
            isLighting = true;
        }
        else
        {
            isLighting = false;
        }
    }
}
