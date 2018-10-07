using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DisplayHealth : MonoBehaviour {

	private float curHealth;
    private float maxHealth;
    public GameObject player;
    private PlayerCollider _playerCollider;
    public Image healthBar;
    public RectTransform feedBackObject;

    private void Start()
    {
        _playerCollider = player.GetComponent<PlayerCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(healthBar.fillAmount - _playerCollider.curHealth / _playerCollider.maxHealth) > 0.0001f)
        {
            if (DOTween.IsTweening(feedBackObject))
            {
                feedBackObject.DOComplete();
            }
            feedBackObject.DOPunchScale(Vector3.one * 0.14f, 0.18f);
            healthBar.fillAmount = _playerCollider.curHealth / _playerCollider.maxHealth;
        }
    }
}
