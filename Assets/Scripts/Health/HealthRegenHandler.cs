using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegenHandler : MonoBehaviour
{
    [SerializeField] private float healthRegenPerSecond = 5;
    
    private HealthHandler _healthHandler;
    private bool _healthRegenApplied;

    private void Start()
    {
        _healthHandler = GetComponent<HealthHandler>();
    }

    private void Update()
    {
        if (_healthRegenApplied == false && _healthHandler.Health < _healthHandler.MaxHealth)
        {
            StartCoroutine(RegenHealth());
        }
    }

    private IEnumerator RegenHealth()
    {
        _healthHandler.GainHealth(healthRegenPerSecond);
        _healthRegenApplied = true;
        yield return new WaitForSeconds(1);
        _healthRegenApplied = false;
    }
}
