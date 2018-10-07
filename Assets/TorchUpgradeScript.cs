using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchUpgradeScript : MonoBehaviour {

    public GameObject player;
    public List<TorchIsLit> torches;
    private float torchLifetime;
    public PlayerLighter playerLighter;
    public Text text;
    public int curPrice;
    public int priceIncrement;
    public float torchlifeIncrement;

    private void Start()
    {
        playerLighter = player.GetComponent<PlayerLighter>();
        torchLifetime = torches[0].lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = curPrice.ToString() + "; Torch Lifetime+";
    }

    public void upgradeLifetIme()
    {
        if (playerLighter.points >= curPrice)
        {
            playerLighter.points -= curPrice;
            curPrice += priceIncrement;
            foreach(var item in torches)
            {
                item.lifetime += torchlifeIncrement;
            }
        }
    }
}
