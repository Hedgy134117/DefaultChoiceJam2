using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchIsLit : MonoBehaviour {


    //As told I said in TorchBurnout, we won't be using TorhcBurnout, the reason is simple : It's easier and more readable to do the lifetime stuff here.
    //A torch is a pretty simple object with a pretty simple behaviour, so we can script its behaviour in only one script

    //There will probably be ducplicate explanations as I don't know in what order you are going to read this (if you read it x) )
    //So, FindGameObjectWithTag is really super slow and you can't afford to do it every frame, you're just going to kill your fps
    //The best way is to do that only one time and to store the object in a variable, since the player is always the same


    public GameObject torchLight;
    private PlayerLighter _playerLighter; //this is where we will store the playerLighter object. In C# everything that can be passed by reference is passed by reference (That mean what is stored in it is not 
                                          //a copy of the object, but a direct access to it
    public float lifetime; //Just moved them here
    private float _lifeTime;
    //private bool isLighting; //I commented it because you don't need a duplicate since you can access the variable directly

    private void Start()
    {
        _lifeTime = lifetime;
        _playerLighter = FindObjectOfType<PlayerLighter>(); //Storing the Component in the variable
        //this work only because we know we have only one playerlighter in the scene, if there were more than one, this function will only return the first one it finds
    }
   
    private bool IsPlayerLigthing() //this function return a boolean, so you can use it directly in a if()
    {
        return _playerLighter.isLighting; //I return the value of the variable isLighting of the stored PlayerLighter Component
    }

    //And here is almost just a copy past of TorchBurnout
    private void Update()
    {
        if (torchLight.activeSelf == true) //Check if torchlight is active
        {
            _lifeTime -= Time.deltaTime;  
            if (_lifeTime <= 0) // check if lifetime is less than/equal to 0 (vérifier si le lifetime est inférieur ou égal à zero)
            {
                _lifeTime = lifetime; // reset lifetime (réinitialiser la duree)
                torchLight.SetActive(false);// make torchlight inactive (fait le torchlight inactif)
            }
        }
    }


    //TODO : Make a trigger zone around the torch so you don't have to literaly kiss the cube every time you want to light a torch
    //This is good, I just replaced if(isLighting == true) by the function that return directly the variable
    private void OnCollisionStay(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))// Check if player is touching the torch & lighting it (Verifie si le joueur est entrain de toucher la lampe et de l'allumer)
        {
            if(IsPlayerLigthing() == true)
            {
                torchLight.SetActive(true); // Make the light of the torch appear (fais apparaitre la lumiere de la lampe )
            }
        }
    }


    //// Get the light variable from the player (prende la variable lumiere du joueur)
    //bool getLight() //function can return a value, here, a boolean
    //{

    //    isLighting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLighter>().isLighting;
    //}
    //void Update()
    //{
        //getLight();
    //}

}
