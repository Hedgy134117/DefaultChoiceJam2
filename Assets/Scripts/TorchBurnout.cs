using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBurnout : MonoBehaviour {


    //The thing is if you use FindGameObjectWithTag, you will get the first object with the corresponding tag. So if you have more than one torch, it won't work
    //Plus, FindGameObjectWithTag is something you should avoid, it's super slow and there is almost always way to have direct access to object instance
    //Here, the thing to do would be : One GetComponentInParent<TorchIsLit>() in the start, and you save the reference in a variable (to avoid doing GetComponent every frame, because it's slow too)
    //As I won't be using this script (see TorchIsLit), I will just make write and comment the way to do it but I won't be using it

    public float lifetime;
    private float _lifeTime; // it's not important but the convention is to put an underscore before the name of a private variable (I added it)
    private TorchIsLit _torchIsLit; //This is where I will store the object TorchIsLit that is on the parent. In C# everything that can be passed by reference is passed by reference (That mean what is stored in it is not 
                                    //a copy of the object, but a direct access to the object

    private void Start()
    {
        _lifeTime = lifetime;
        _torchIsLit = GetComponentInParent<TorchIsLit>(); //Here I'm storing the Component TorchIsLit that is on the parent in my variable
    }

    //The following code is what you didi but with the variable instead of the FindGameObjectWithTag + GetComponent
    private void Update()
    {
        if (_torchIsLit.torchLight.activeSelf == true) //Check if torchlight is active
        {
            _lifeTime -= Time.deltaTime;

            // check if lifetime is less than/equal to 0 (vérifier si le lifetime est inférieur ou égal à zero)
            if (_lifeTime <= 0)
            {
                _lifeTime = lifetime; // reset lifetime (réinitialiser la duree)
                _torchIsLit.torchLight.SetActive(false);// make torchlight inactive (fait le torchlight inactif)
            }
        }
    }


    //Here is what you did (I left it so you can compare
    //private void Start()
    //{
    //    _lifeTime = lifetime;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // Check if torch is lit (verifie si la lampe est allumee)
    //    if (GameObject.FindGameObjectWithTag("Torch").GetComponent<TorchIsLit>().torchLight.activeSelf == true)
    //    {
    //        // lifetime - seconds
    //        _lifeTime -= Time.deltaTime;

    //        // check if lifetime is less than/equal to 0 (verifie si le lifetime est moins que/egal que zero)
    //        if (_lifeTime <= 0)
    //        {
    //            // reset lifetime (remettre la duree)
    //            _lifeTime = lifetime;
    //            // make torchlight inactive (fait le torchlight inactif)
    //            GameObject.FindGameObjectWithTag("Torch").GetComponent<TorchIsLit>().torchLight.SetActive(false);
    //        }
    //    }
    //}
}
