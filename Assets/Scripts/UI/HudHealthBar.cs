using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHealthBar : MonoBehaviour
{
    [SerializeField] private HealthHandler healthHandler;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _image.fillAmount = healthHandler.Health / healthHandler.MaxHealth;
    }
}
