using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float damage = 10;
    
    private GameObject _validEnemy;
    private Transform _target;

    public void Init(Transform target)
    {
        this._target = target;
    }
    
    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        var delta = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, delta);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_validEnemy.tag))
        {
            other.gameObject.GetComponentInParent<HealthHandler>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetValidEnemy(GameObject enemy)
    {
        _validEnemy = enemy;
    }
}
