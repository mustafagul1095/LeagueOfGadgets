using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManaText : MonoBehaviour
{
    [SerializeField] private ManaHandler manaHandler;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = manaHandler.Mana + " / " + manaHandler.MaxMana;
    }
}
