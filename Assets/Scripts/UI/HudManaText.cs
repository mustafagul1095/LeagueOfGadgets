using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManaText : MonoBehaviour
{
    [SerializeField] private ManaHandler manaHandler;
    private TextMeshProUGUI _text;

    private void OnPlayerSelected()
    {
        manaHandler = FindObjectOfType<ManaHandler>();
    }
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (manaHandler != null)
        {
            _text.text = manaHandler.Mana + " / " + manaHandler.MaxMana;
        }
    }
}
