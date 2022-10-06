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

    private void Update()
    {
        _image.fillAmount = manaHandler.Mana / manaHandler.MaxMana;
    }
}
