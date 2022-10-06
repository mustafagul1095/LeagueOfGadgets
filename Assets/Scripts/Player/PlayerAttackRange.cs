using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{
    [SerializeField] private float attackRange = 0.001f;
    [SerializeField] private MouseHandler mouseHandler;
    public float AttackRange => attackRange;
    private GameObject _enemy;
    public GameObject Enemy => _enemy;
    private bool _targetInRange;
    public bool IsTargetInRange => _targetInRange;

    private void Awake()
    {
        mouseHandler.OnMouseRightClick += OnMouseRightClick;
    }

    public void CheckRange()
    {
        if (_enemy != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, _enemy.transform.position);
            if (distanceToEnemy < attackRange)
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

    private void OnMouseRightClick()
    {
        _enemy = mouseHandler.SelectedObject;
    }
}
