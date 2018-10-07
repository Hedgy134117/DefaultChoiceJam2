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
    public Transform scaleObject;
    
    private Vector3 _initialScale;
	// Use this for initialization
	void Start ()
    {
        _light = GetComponent<Light>();

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



        }
    }
}
