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

    private void OnPlayerSelected()
    {
        healthHandler = FindObjectOfType<HealthHandler>();
    }
    
    private void Update()
    {
        if (healthHandler != null)
        {
            _text.text = healthHandler.Health + " / " + healthHandler.MaxHealth;   
        }
    }
}
