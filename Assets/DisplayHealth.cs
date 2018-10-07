using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour {

	private float curHealth;
    private float maxHealth;
    public GameObject player;
    public Text text;

    // Update is called once per frame
    void Update () {
        curHealth = player.GetComponent<PlayerCollider>().curHealth;
        maxHealth = player.GetComponent<PlayerCollider>().maxHealth;
        text.text = curHealth.ToString();
	}
}
