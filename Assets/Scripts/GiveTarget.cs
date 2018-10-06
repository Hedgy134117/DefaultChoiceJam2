using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GiveTarget : MonoBehaviour {

    public Transform target;
    private AIPath aiPath;
	// Use this for initialization
	void Start () {
        aiPath = GetComponent<AIPath>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        aiPath.target = target;
	}
}
