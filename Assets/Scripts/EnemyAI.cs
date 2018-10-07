using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour {



    public float wanderSpeed = 2f;
    public float chaseSpeed = 4f;
    public float wanderRepathTime = 5f;
    public float wanderRepathOffset = 2f;
    public float areaSizeX = 30;
    public float areaSizeZ = 30;


    private AIPath _AIPath;
    private Transform _player;
    private bool _chasing;
    private float _wanderTimeLeft;


    // Use this for initialization
    void Start ()
    {
        _AIPath = GetComponent<AIPath>();
        _player = PlayerMovement.instance.transform;
        _chasing = true;
        _AIPath.maxSpeed = chaseSpeed;
        AstarPath.active.logPathResults = PathLog.OnlyErrors;
        _AIPath.target = _player;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (AstarPath.active.GetNearest(_player.position).node.Walkable)
        {
            Chase();
        }
        else
        {
            Wander();
        }
    }


    private void Chase()
    {
        if (!_chasing)
        {
            _chasing = true;
            _AIPath.maxSpeed = chaseSpeed;
            _AIPath.target = _player;
        }
    }

    private void Wander()
    {
        if (_chasing)
        {
            _chasing = false;
            _AIPath.maxSpeed = wanderSpeed;
            _AIPath.target = null;

            _wanderTimeLeft = wanderRepathTime + Random.Range(-wanderRepathOffset, wanderRepathOffset);
            _AIPath.destination = GetRandomWalkableTile();
        }
        _wanderTimeLeft -= Time.deltaTime;
        if (_wanderTimeLeft < 0 || _AIPath.reachedEndOfPath)
        {
            _wanderTimeLeft = wanderRepathTime + Random.Range(-wanderRepathOffset, wanderRepathOffset);
            _AIPath.destination = GetRandomWalkableTile();

        }
    }


    private Vector3 GetRandomWalkableTile(int maxTry = 15)
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < maxTry; i++)
        {
            pos.x = Random.Range(-areaSizeX / 2, areaSizeX / 2);
            pos.z = Random.Range(-areaSizeZ / 2, areaSizeZ / 2);
            if (AstarPath.active.GetNearest(pos).node.Walkable)
            {
                break;
            }
        }
        return pos;
    }
}
