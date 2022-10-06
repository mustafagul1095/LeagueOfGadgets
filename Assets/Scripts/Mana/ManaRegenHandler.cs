using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegenHandler : MonoBehaviour
{
    [SerializeField] private float manaRegenPerSecond = 10;
    
    private ManaHandler _manaHandler;
    private bool _manaRegenApplied;

    private void Start()
    {
        _manaHandler = GetComponent<ManaHandler>();
    }

    private void Update()
    {
        if (_manaRegenApplied == false)
        {
            StartCoroutine(RegenHealth());
        }
    }

    private IEnumerator RegenHealth()
    {
        _manaHandler.GainMana(manaRegenPerSecond);
        _manaRegenApplied = true;
        yield return new WaitForSeconds(1);
        _manaRegenApplied = false;
    }
}
