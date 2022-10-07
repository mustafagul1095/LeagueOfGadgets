using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentHealthBar : MonoBehaviour
{
    [SerializeField] private float healthBarLengthFactor = 0.1f;
    
    private HealthHandler _healthHandler;
    private Vector3 _localScale;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _healthHandler = GetComponentInParent<HealthHandler>();
        _localScale = _transform.localScale;
    }

    private void Update()
    {
        _transform.localScale = new Vector3(_healthHandler.Health * healthBarLengthFactor, _localScale.y, _localScale.z);
        var localPosition = _transform.localPosition;
        localPosition.x = -((_healthHandler.MaxHealth - _healthHandler.Health) * healthBarLengthFactor)/2;
        _transform.localPosition = localPosition;
    }
}
