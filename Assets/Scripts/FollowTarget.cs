using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform target;
    public float followSpeed;
    private Vector3 _dist;
    private Vector3 _targetMove;

    private void Start()
    {
        _dist = transform.position - target.position;
    }

    private void Update()
    {
        _targetMove = target.position + _dist;
        transform.position += (_targetMove - transform.position) * Time.deltaTime * followSpeed;
    }

}
