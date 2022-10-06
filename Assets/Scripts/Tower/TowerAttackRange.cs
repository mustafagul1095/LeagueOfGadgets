using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackRange : MonoBehaviour
{
    [SerializeField] private Tower tower;
    
    public bool TargetIsAcquired => _targetedEnemy != null;
    private GameObject _targetedEnemy;
    private SideHandler _sideHandler;
    public GameObject TargetedEnemy => _targetedEnemy;
    private float _closestTargetRange = float.MaxValue;
    private GameObject _closestEnemy;

    private void Start()
    {
        _sideHandler = tower.gameObject.GetComponentInChildren<SideHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherSideHandler = other.GetComponent<SideHandler>();
        if (otherSideHandler == null) 
            return;
        if (!otherSideHandler.Equals(_sideHandler))
        {
            if (TargetIsAcquired == false)
            {
                _targetedEnemy = other.gameObject;
            }
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        var otherSideHandler = other.GetComponent<SideHandler>();
        if (otherSideHandler == null) 
            return;
        if (!otherSideHandler.Equals(_sideHandler))
        {
            if (_closestEnemy == null ||
                Vector3.Distance(transform.position, other.transform.position) < _closestTargetRange)
            {
                if(other.gameObject !=_targetedEnemy)
                {
                    _closestEnemy = other.gameObject;
                    _closestTargetRange = Vector3.Distance(transform.position, other.transform.position);
                } 
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _targetedEnemy)
        {
            ChangeTarget();
        }

        if (other.gameObject == _closestEnemy)
        {
            _closestEnemy = null;
        }
    }
    
    private void ChangeTarget()
    {
        _targetedEnemy = _closestEnemy;
        _closestEnemy = null;
    }

}
