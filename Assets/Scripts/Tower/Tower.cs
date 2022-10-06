using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Vector3 bulletInitOffset = Vector3.one * 5;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackPeriod = 1.5f;

    private TowerAttackRange _towerAttackRange;
    
    private bool _isAttacking;
    private GameObject _enemy;
    private Vector3 _targetPos;

    private void Start()
    {
        _towerAttackRange = GetComponentInChildren<TowerAttackRange>();
    }

    private void Update()
    {
        if (_towerAttackRange.TargetIsAcquired && !_isAttacking)
        {
            AttackPlayer(_towerAttackRange.TargetedEnemy);
        }
    }

    private IEnumerator Attack()
    {
        if (!_isAttacking)
        {
            if (_enemy != null)
            {
                var go = Instantiate(bulletPrefab, transform.position + bulletInitOffset, Quaternion.identity);
                var bullet = go.GetComponent<Bullet>();
                bullet.Init(_enemy.transform);
                bullet.SetValidEnemy(_enemy);
                _isAttacking = true;
            }
            yield return new WaitForSeconds(attackPeriod);
            _isAttacking = false;
        }
    }
    
    public void AttackPlayer(GameObject other)
    {
        _enemy = other;
        StartCoroutine(Attack());
    }
}
