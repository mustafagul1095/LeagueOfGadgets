using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerESkill : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackPeriod = 1f;
    [SerializeField] private Vector3 bulletPosInitOffset;
    [SerializeField] private float eSkillRange = 100f;
    [SerializeField] private MouseHandler mouseHandler;
    [SerializeField] private float manaCost = 10f;

    private ManaHandler _manaHandler;
    private Vector3 _targetPosition;
    private bool _isShooting;

    private void Start()
    {
        _manaHandler = GetComponent<ManaHandler>();
        mouseHandler = FindObjectOfType<MouseHandler>();
    }

    public void CastESkill()
    {
        if (_manaHandler.IsManaEnough)
        {
            var position = transform.position;
            var eSkillDir = (mouseHandler.MousePosOnTerrain - position).normalized;
            _targetPosition = position + eSkillDir * eSkillRange;
            AttackInDirection(_targetPosition);
        }
    }

    private IEnumerator EAttack(Vector3 targetPos)
    {
        _manaHandler.SpendMana(manaCost);
        var go = Instantiate(bulletPrefab, transform.position + bulletPosInitOffset, Quaternion.identity);
        var bullet = go.GetComponent<ESkillBullet>();
        bullet.Init(targetPos, 6);
        _isShooting = true;
        yield return new WaitForSeconds(attackPeriod);
        _isShooting = false;
    }

    private void AttackInDirection(Vector3 targetPos)
    {
        if (_isShooting == false)
        {
            StartCoroutine(EAttack(targetPos));
        }
    }
}
