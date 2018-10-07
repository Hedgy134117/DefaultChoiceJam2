using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    //public bool azertyKeyboard;//Because french people are annoying with their weird keyboard
    public GameObject[] wheels;
    private Rigidbody rb;

    public static PlayerMovement instance { private set; get; }

    private void Awake()
    {
        if (instance == null) instance = this;
        if (instance != this) Destroy(this);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Here it's a little tricky : Depending on your computer speed, you won't have the same framerate, so if you have a good computer, Update will be clled more often meaning that... Your player will be faster too !
    //You have to multiply the speed by the deltaTime to something consistent on different computer (and that's why you had to take a really small number for speed)

    //TODO : Use rigidbody velocity instead of Translate to avoid glitch when you try to move into a wall (And store the rigibody in a variable to avoid GetCompoennt every frame :D ) Done
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        rb.velocity = dir * speed;

        if(dir !=Vector3.zero)
            transform.right = dir;
        if (rb.velocity != Vector3.zero)
            foreach (var wheel in wheels) wheel.transform.Rotate(Vector3.up * 360 * Time.deltaTime, Space.Self);
    }
    //{
    //    if (azertyKeyboard)
    //    {
    //        // Forward (avancer)
    //        if (Input.GetKey("z"))
    //        {
    //            rb.velocity = Vector3.right * speed;
    //            //transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    //        }
    //        // Left (a gauche)
    //        if (Input.GetKey("q"))
    //        {
    //            rb.velocity = Vector3.left * speed;

    //            //transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    //        }
    //    }
    //    else
    //    {
    //        // Forward (avancer)
    //        if (Input.GetKey("w"))
    //        {
    //            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    //        }
    //        // Left (a gauche)
    //        if (Input.GetKey("a"))
    //        {
    //            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    //        }
    //    }
    //    // Down (plus loin(?) reculer) "plus loin" means "farther"
    //    if(Input.GetKey("s"))
    //    {
    //        transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
    //    }
    //    // Right (a droite)
    //    if(Input.GetKey("d"))
    //    {
    //        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    //    }
	//}
}
