using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    public float MaxHealth => maxHealth;
    
    private float _health = 100f;
    public float Health => _health;

    private void Start()
    {
        _health = maxHealth;
    }

    private void Update()
    {
        if (_health > MaxHealth)
        {
            _health = MaxHealth;
        }
    }
    
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken", SendMessageOptions.DontRequireReceiver);
        _health -= damage;
        if (_health <= 0)
        {
            if (transform.parent.gameObject != null)
            {
                Debug.Log("DestroyParent");
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }

    public void GainHealth(float cureAmount)
    {
        if (_health < maxHealth)
        {
            _health += cureAmount;
        }
    }
}
