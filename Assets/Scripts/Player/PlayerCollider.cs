using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCollider : MonoBehaviour {

    public float curHealth;
    public float maxHealth;
    public float invicibilityFrameTime = 0.5f;
    private float _lastHit;
    private MeshRenderer _renderer;
    private Color _baseColor;
    private void Start()
    {
        curHealth = maxHealth;
        _lastHit = -invicibilityFrameTime;
        _renderer = GetComponent<MeshRenderer>();
        _baseColor = _renderer.material.color;
    }

    private void OnCollisionStay(Collision collider)
    {
        if(collider.gameObject.CompareTag("Enemy") && Time.time - _lastHit > invicibilityFrameTime)
        {
            curHealth -= 1;
            _lastHit = Time.time;
            _renderer.material.DOColor(Color.red, 0.09f).SetEase(Ease.OutCubic).OnComplete(() => _renderer.material.DOColor(_baseColor, 0.09f).SetEase(Ease.InCubic));
            transform.DOPunchScale(Vector3.one * 0.2f, 0.18f);
        }
    }
}
