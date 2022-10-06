using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxManaBar : MonoBehaviour
{
    [SerializeField] private float manaBarLengthFactor = 0.1f;
    
    private ManaHandler _manaHandler;
    private Vector3 _localScale;

    private void Start()
    {
        _localScale = GetComponent<Transform>().localScale;
        _manaHandler = GetComponentInParent<ManaHandler>();
        _localScale = new Vector3(_manaHandler.MaxMana * manaBarLengthFactor, _localScale.y, _localScale.z);
        transform.localScale = _localScale;
    }
}
