using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlickeringLight : MonoBehaviour {

    private Light _light;
    public float timeChange = 0.4f;
    public float offsetTimeChange = 0.05f;
    public float baseIntensity = 1;
    public float intensityVariation;
    public bool lerp;
    public Transform scaleObject;


    private float _timer;
    private float _targetIntensity;
    private float _lastIntensity;
    private Vector3 _initialScale;
    private Vector3 _lastScale;
    private Vector3 _targetScale;
	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();
        _lastIntensity = _light.intensity;

        if (scaleObject != null) _initialScale = scaleObject.transform.localScale;
	}

    private void Update()
    {
        if(DOTween.IsTweening(_light) == false)
        {
            float duration = timeChange + Random.Range(-offsetTimeChange, offsetTimeChange);
            float intensity = baseIntensity + Random.Range(-intensityVariation, intensityVariation);

            _light.DOIntensity(intensity, duration);
            if (scaleObject != null) scaleObject.DOScale(_initialScale * (1 + ((intensity - baseIntensity) / baseIntensity) * 0.09f), duration - 0.001f);
            Debug.Log(intensity + " " + duration);


        }

        //_timer -= Time.deltaTime;
        //if (_timer <= 0)
        //{
        //    _timer = Random.Range(timeChange - offsetTimeChange, timeChange + offsetTimeChange);
        //    _targetIntensity = Random.Range(baseIntensity - intensityVariation, baseIntensity + intensityVariation);
        //    _lastIntensity = _light.intensity;
        //    if(scaleObject != null)
        //    {
        //        _lastScale = scaleObject.transform.localScale;
        //        _targetScale = _initialScale * (1 + (_targetIntensity - baseIntensity) / baseIntensity);
        //    }

        //}
        //if (lerp)
        //{
        //    _light.intensity = Mathf.Lerp(_lastIntensity, _targetIntensity, _timer / timeChange);
        //    if (scaleObject != null) scaleObject.localScale = Vector3.Lerp(_lastScale, _targetScale, _timer / timeChange);
        //}
        //else
        //{
        //    _light.intensity = _targetIntensity;
        //    if (scaleObject != null) scaleObject.localScale = _targetScale;

        //}
    }


}
