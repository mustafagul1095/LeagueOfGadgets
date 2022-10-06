using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthBar : MonoBehaviour
{
    [SerializeField] private float healthBarLengthFactor = 0.1f;
    
    private HealthHandler _healthHandler;
    private Vector3 _localScale;

    private void Start()
    {
        _localScale = GetComponent<Transform>().localScale;
        _healthHandler = GetComponentInParent<HealthHandler>();
        _localScale = new Vector3(_healthHandler.MaxHealth * healthBarLengthFactor, 1, 1);
        transform.localScale = _localScale;
    }
}
