using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaText : MonoBehaviour
{
    private ManaHandler _manaHandler;
    private TextMeshPro _tmPro;

    private void Start()
    {
        _manaHandler = GetComponentInParent<ManaHandler>();
        _tmPro = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        _tmPro.text = _manaHandler.Mana + " / " + _manaHandler.MaxMana;
    }
}
