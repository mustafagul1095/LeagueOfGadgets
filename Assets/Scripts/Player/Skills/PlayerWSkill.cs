using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWSkill : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackPeriod = 1f;
    [SerializeField] private Vector3 bulletPosInitOffset;
    [SerializeField] private MouseHandler mouseHandler;
    [SerializeField] private float manaCost = 20f;
    [SerializeField] private float attackRange = 500f;

    private ManaHandler _manaHandler;
    private bool _isShooting;
    private bool _targetInRange;
    private Vector3 _wSkillTargetPos;
    
    private void Start()
    {
        _manaHandler = GetComponent<ManaHandler>();
    }
    
    private IEnumerator WShoot()
    {
        if (_targetInRange)
        {
            _manaHandler.SpendMana(manaCost);
            var go = Instantiate(bulletPrefab, transform.position + bulletPosInitOffset, Quaternion.identity);
            var bullet = go.GetComponent<WSkillBullet>();
            bullet.Init(_wSkillTargetPos, 6);
            _isShooting = true;
            yield return new WaitForSeconds(attackPeriod);
            _isShooting = false;
        }
    }
    
    public void CastWSkill()
    {
        if (_manaHandler.IsManaEnough)
        {
            CheckRange();
            _wSkillTargetPos = mouseHandler.MousePosOnTerrain;
            if (!_isShooting)
            {
                StartCoroutine(WShoot());
            }
        }
    }
    
    public void CheckRange()
    {
        if (mouseHandler != null)
        {
            float distonceToTarget = Vector3.Distance(transform.position, _wSkillTargetPos);
            if (distonceToTarget < attackRange)
            {
                _targetInRange = true;
            }
            else
            {
                _targetInRange = false;
            }
        }
        else
        {
            _targetInRange = false;
        }
    }
}
