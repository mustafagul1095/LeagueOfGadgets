using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    private HealthHandler _healthHandler;
    private TextMeshPro _tmPro;

    private void Start()
    {
        _healthHandler = GetComponentInParent<HealthHandler>();
        _tmPro = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        _tmPro.text = _healthHandler.Health + " / " + _healthHandler.MaxHealth;
    }
}
