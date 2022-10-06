using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaHandler : MonoBehaviour
{
    [SerializeField] private float maxMana = 100f;
    public float MaxMana => maxMana;
    
    private float _mana = 100f;
    public float Mana => _mana;

    private bool _isManaEnough;
    public bool IsManaEnough => _isManaEnough;

    private void Start()
    {
        _mana = maxMana;
        _isManaEnough = true;
    }

    private void Update()
    {
        if (_mana > MaxMana)
        {
            _mana = MaxMana;
        }
    }

    public void SpendMana(float manaCost)
    {
        BroadcastMessage("OnManaSpent", SendMessageOptions.DontRequireReceiver);
        if (_mana >= manaCost)
        {
            _mana -= manaCost;
            _isManaEnough = true;
        }
        else
        {
            _isManaEnough = false;
        }
    }
    
    public void GainMana(float manaIncreaseAmount)
    {
        if (_mana < maxMana)
        {
            _mana += manaIncreaseAmount;
        }
    }
}
