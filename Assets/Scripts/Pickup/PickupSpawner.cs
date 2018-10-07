using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    public GameObject prefab;
    public float spawnTime = 3;
    public Vector2 areaSize;

    private float _lastSpawnTime;
	// Use this for initialization
	void Start ()
    {
        _lastSpawnTime = -spawnTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Time.time - _lastSpawnTime > spawnTime)
        {
            Instantiate(prefab, new Vector3(
                Random.Range(-areaSize.x / 2, areaSize.x / 2),
                1.5f,
                Random.Range(-areaSize.y / 2, areaSize.y / 2)), Quaternion.Euler(new Vector3(45,45,45)));
            _lastSpawnTime = Time.time;
        }
        

	}
}
