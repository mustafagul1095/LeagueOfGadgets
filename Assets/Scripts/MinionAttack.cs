using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttack : MonoBehaviour
{
    [SerializeField] private Vector3 bulletInitOffset = Vector3.one * 5;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackPeriod = 1f;
    
    private GameObject _enemy;
    private bool _canAttack = true;
    public bool CanAttack => _canAttack;
    public bool isAttacking;
    
    private IEnumerator Attack()
    {
        if (_canAttack && !isAttacking)
        {
            if (_enemy != null)
            {
                var go = Instantiate(bulletPrefab, transform.position + bulletInitOffset, Quaternion.identity);
                var bullet = go.GetComponent<Bullet>();
                bullet.Init(_enemy.transform);
                bullet.SetValidEnemy(_enemy);
                isAttacking = true;
            }
            yield return new WaitForSeconds(attackPeriod);
            isAttacking = false;
        }
    }
    
    public void StopAttack()
    {
        _canAttack = false;
    }
    
    public void AttackEnemy(GameObject enemy)
    {
        _canAttack = true;
        _enemy = enemy;
        StartCoroutine(Attack());
    }
}
