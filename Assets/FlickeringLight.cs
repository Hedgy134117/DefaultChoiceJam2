using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {

    private Light _light;
    public float timeChange = 0.4f;
    public float offsetTimeChange = 0.05f;
    public float baseIntensity = 1;
    public float intensityVariation;
    public bool lerp;
    private float _timer;
    private float _targetIntensity;
    private float _lastIntensity;
	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();
        _lastIntensity = _light.intensity;
	}

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = Random.Range(timeChange - offsetTimeChange, timeChange + offsetTimeChange);
            _targetIntensity = Random.Range(baseIntensity - intensityVariation, baseIntensity + intensityVariation);
            _lastIntensity = _light.intensity;
        }
        if (lerp)
        {
            _light.intensity = Mathf.Lerp(_lastIntensity, _targetIntensity, _timer / timeChange);
        }
        else
        {
            _light.intensity = _targetIntensity;

        }
    }


}
