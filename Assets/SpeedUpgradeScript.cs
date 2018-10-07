using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpgradeScript : MonoBehaviour {

    public GameObject player;
    public PlayerLighter playerLighter;
    public PlayerMovement playerMovement;
    public Text text;
    public int curPrice;
    public int priceIncrement;
    public float speedIncrement;

    private void Start()
    {
        playerLighter = player.GetComponent<PlayerLighter>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update () {
        text.text = curPrice.ToString() + "; Increase speed";
	}

    public void upgradeSpeed()
    {
        if (playerLighter.points >= curPrice)
        {
            playerLighter.points -= curPrice;
            curPrice += priceIncrement;
            playerMovement.speed += speedIncrement;
        }
    }
}
