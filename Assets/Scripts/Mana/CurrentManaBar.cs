using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentManaBar : MonoBehaviour
{
    [SerializeField] private float manaBarLengthFactor = 0.1f;
    
    private ManaHandler _manaHandler;
    private Vector3 _localScale;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _manaHandler = GetComponentInParent<ManaHandler>();
        _localScale = _transform.localScale;
    }

    private void Update()
    {
        _transform.localScale = new Vector3(_manaHandler.Mana * manaBarLengthFactor, _localScale.y, _localScale.z);
        var localPosition = _transform.localPosition;
        float localPositionX = localPosition.x;
        localPositionX = -((_manaHandler.MaxMana - _manaHandler.Mana) * manaBarLengthFactor)/2;
        localPosition = new Vector3(localPositionX, localPosition.y, localPosition.z);
        _transform.localPosition = localPosition;
    }
}
