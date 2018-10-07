using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetManager : MonoBehaviour {

    public GameObject player;
    public GameObject resetButton;
    public GameObject upgradeButton;

    private PlayerCollider pc;

    private void Start()
    {
        pc = player.GetComponent<PlayerCollider>();
    }

    // Update is called once per frame
    void Update () {

        if(pc.curHealth <= 0)
        {
            Time.timeScale = 0;
            upgradeButton.SetActive(false);
            resetButton.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
        Time.timeScale = 1;

        }
    }

    public void resetGame()
    {
        resetButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
