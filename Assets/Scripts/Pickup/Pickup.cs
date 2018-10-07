using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerLighter.instance.lighterCount++;
            Destroy(gameObject);
        }
    }
}
