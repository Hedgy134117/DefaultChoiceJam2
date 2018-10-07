using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLighter : MonoBehaviour {

    public bool isLighting { get { return _keyPressed && lighterCount > 0; } }
    private bool _keyPressed;
    public int lighterCount = 0;

    public static PlayerLighter instance { private set; get; }

    private void Awake()
    {
        if (instance == null) instance = this;
        if (instance != this) Destroy(this);
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKey(KeyCode.E)) 
        {
            _keyPressed = true;
        }
        else
        {
            _keyPressed = false;
        }
    }

}
