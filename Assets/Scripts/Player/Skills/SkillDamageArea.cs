using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamageArea : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float damagePeriod = 0.5f;
    [SerializeField] private float lifeSpan = 3f;
    
    private int _validEnemyLayer;
    private float _damageTimer;

    public void Init(int layerNum)
    {
        _damageTimer = 0;
        _validEnemyLayer = layerNum;
        StartCoroutine(StartLifeSpan());
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == _validEnemyLayer)
        {
            _damageTimer += Time.deltaTime;
            if (_damageTimer > damagePeriod)
            {
                other.gameObject.GetComponentInParent<HealthHandler>().TakeDamage(damage);
                _damageTimer = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _validEnemyLayer)
        {
            _damageTimer = 0;    
        }
    }
    
    private IEnumerator StartLifeSpan()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }
}
