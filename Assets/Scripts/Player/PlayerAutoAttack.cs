using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackPeriod = 1f;
    [SerializeField] private Vector3 bulletPosInitOffset;
    [SerializeField] private float attackRange = 100f;
    public float AttackRange => attackRange;
    
    private bool _isShooting = false;
    private PlayerAttackRange _playerAttackRange;
    private bool _targetInRange = false;

    private IEnumerator Attack()
    {
        if (_targetInRange)
        {
            var go = Instantiate(bulletPrefab, transform.position + bulletPosInitOffset, Quaternion.identity);
            var bullet = go.GetComponent<Bullet>();
            bullet.SetValidEnemy(_playerAttackRange.Enemy);
            bullet.Init(_playerAttackRange.Enemy.transform);
            _isShooting = true;
            yield return new WaitForSeconds(attackPeriod);
            _isShooting = false;
        }
    }

    private void Start()
    {
        _playerAttackRange = GetComponent<PlayerAttackRange>();
    }
    
    public void AutoAttackInRange()
    {
        if (_playerAttackRange.Enemy != null)
        {
            _playerAttackRange.CheckRange();
            _targetInRange = _playerAttackRange.IsTargetInRange;
            
            if (Input.GetKeyDown(KeyCode.Mouse1) && !_isShooting)
            {
                StartCoroutine(Attack());
            }
        }
    }
    
}
