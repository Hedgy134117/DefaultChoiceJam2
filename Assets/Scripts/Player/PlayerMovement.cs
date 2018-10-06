using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public bool azertyKeyboard;//Because french people are annoying with their weird keyboard
	// Update is called once per frame

    //Here it's a little tricky : Depending on your computer speed, you won't have the same framerate, so if you have a good computer, Update will be clled more often meaning that... Your player will be faster too !
    //You have to multiply the speed by the deltaTime to something consistent on different computer (and that's why you had to take a really small number for speed)

    //TODO : Use rigidbody velocity instead of Translate to avoid glitch when you try to move into a wall (And store the rigibody in a variable to avoid GetCompoennt every frame :D )
	void Update () {
        if (azertyKeyboard)
        {
            // Forward (avancer)
            if (Input.GetKey("z"))
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            // Left (a gauche)
            if (Input.GetKey("q"))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
        }
        else
        {
            // Forward (avancer)
            if (Input.GetKey("w"))
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            // Left (a gauche)
            if (Input.GetKey("a"))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
        }
        // Down (plus loin(?) reculer) "plus loin" means "farther"
        if(Input.GetKey("s"))
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        // Right (a droite)
        if(Input.GetKey("d"))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
	}
}
