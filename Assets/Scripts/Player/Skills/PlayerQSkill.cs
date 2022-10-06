using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQSkill : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackPeriod = 1f;
    [SerializeField] private Vector3 bulletPosInitOffset;
    [SerializeField] private MouseHandler mouseHandler;
    [SerializeField] private float manaCost = 5f;

    private ManaHandler _manaHandler;
    private bool _isShooting ;

    private void Start()
    {
        _manaHandler = GetComponent<ManaHandler>();
    }
    
    
    private IEnumerator QAttack()
    {
        _manaHandler.SpendMana(manaCost);
        var go = Instantiate(bulletPrefab, transform.position + bulletPosInitOffset, Quaternion.identity);
        var bullet = go.GetComponent<QSkillBullet>();
        bullet.SetValidEnemyLayer(6);
        bullet.Init(mouseHandler.MousePosOnTerrain);
        _isShooting = true;
        yield return new WaitForSeconds(attackPeriod);
        _isShooting = false;
    }

    public void QSkillCast()
    {
        if (_manaHandler.IsManaEnough)
        {
            if (_isShooting == false)
            {
                StartCoroutine(QAttack());
            }
        }
    }
}
