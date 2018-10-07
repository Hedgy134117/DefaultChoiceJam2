using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform target;
    public float followSpeed;
    private Vector3 _dist;
    private Vector3 _targetMove;
    private Vector3 _lastPos;
    private float _t = 0;

    private void Start()
    {
        _dist = transform.position - target.position;
        _lastPos = transform.position;
    }

    private void Update()
    {
        _t += Time.deltaTime;
        transform.position = Vector3.Lerp(_lastPos, _targetMove, _t / Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        _lastPos = transform.position;
        _targetMove = transform.position + ((target.position + _dist) - _lastPos) * Time.deltaTime * followSpeed ;
    }

}
