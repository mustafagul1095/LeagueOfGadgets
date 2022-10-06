using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20;
    [SerializeField] private float attackingRange = 30;
    [SerializeField] private float stopDistance = 0.01f;
    private MinionRangeHandler _minionRangeHandler;
    
    private Transform _finalDestination;
    private Vector3 _destination;
    private Animator _animator;
    private bool _isAttacking;
    private MinionAttack _minionAttack;
    private Minion _minion;
    private Rigidbody _rigidbody;

    public void Init(MinionRangeHandler minionRangeHandler)
    {
        _animator = GetComponent<Animator>();
        _minionAttack = GetComponent<MinionAttack>();
        _minion = GetComponent<Minion>();
        _finalDestination = _minion.Target;
        _destination = _finalDestination.position;
        _rigidbody = GetComponent<Rigidbody>();
        _minionRangeHandler = minionRangeHandler;
    }

    private void Update()
    {
        RotateTowards(_destination);
        if (_minionRangeHandler.TargetIsAcquired) 
        {
            _animator.SetBool("Walk", false);
             StopMoving();
            _minionAttack.AttackEnemy(_minionRangeHandler.TargetedEnemy);
        }
        else
        {
            MoveTowards(_destination);
            //_minionAttack.StopAttack();
            _animator.SetBool("Walk", true);
        }
    }
    
    private void MoveTowards(Vector3 targetPos)
    {
        Vector3 diff = targetPos - transform.position;
        float step = movementSpeed * Time.deltaTime;
        _rigidbody.velocity = diff.normalized * step;
    }
    
    private void StopMoving()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void RotateTowards(Vector3 targetPos)
    {
        var transform1 = transform;
        transform1.LookAt(targetPos);
        transform.rotation = Quaternion.Euler(0, transform1.eulerAngles.y, 0);
    }
    
    private float StopRange()
    {
        return _isAttacking ? attackingRange : stopDistance;
    }

    public void SetDestination(Vector3 targetDes)
    {
        _destination = targetDes;
    }
}
