using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManaBar : MonoBehaviour
{
    [SerializeField] private ManaHandler manaHandler;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnPlayerSelected()
    {
        manaHandler = FindObjectOfType<ManaHandler>();
        Debug.Log("PlayerSelected--Mana Bar");
    }
    
    private void Update()
    {
        if (manaHandler != null) _image.fillAmount = manaHandler.Mana / manaHandler.MaxMana;
    }
}
