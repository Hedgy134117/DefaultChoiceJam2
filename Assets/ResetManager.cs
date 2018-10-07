using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetManager : MonoBehaviour {

    public GameObject player;
    public GameObject resetButton;
    public GameObject upgradeButton;
    private float curHealth;
	
	// Update is called once per frame
	void Update () {
        curHealth = player.GetComponent<PlayerCollider>().curHealth;
        if(curHealth <= 0)
        {
            upgradeButton.SetActive(false);
            resetButton.SetActive(true);
        }
	}

    public void resetGame()
    {
        resetButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
