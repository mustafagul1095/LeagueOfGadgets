using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudHealthText : MonoBehaviour
{
    [SerializeField] private HealthHandler healthHandler;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = healthHandler.Health + " / " + healthHandler.MaxHealth;
    }
}
