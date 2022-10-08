using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float stopRange = 2f;
    [SerializeField] private MouseHandler mouseHandler;
    
    private Animator _animator;
    private PlayerAttackRange _playerAttackRange;
    private PlayerAutoAttack _playerAutoAttack;
    private Vector3 _destination;
    private PlayerWSkill _playerWSkill;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        mouseHandler.OnMouseRightClick += OnMouseRightClick;
    }

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerAttackRange = GetComponent<PlayerAttackRange>();
        _playerAutoAttack = GetComponent<PlayerAutoAttack>();
        _playerWSkill = GetComponent<PlayerWSkill>();
        _destination = transform.position;
        _rigidbody = GetComponent<Rigidbody>();

    }
    
    private void Update()
    {
        RotatePlayer(_destination);
        if (Vector3.Distance(transform.position, _destination) < StopRange()) 
        {
            StopPlayer();
            _animator.SetBool("Walk", false);
        }
        else
        {
            MovePlayer(_destination);
            _animator.SetBool("Walk", true);
        }
    }

    private void MovePlayer(Vector3 targetPos)
    {
        Vector3 diff = targetPos - transform.position;
        float step = movementSpeed * Time.deltaTime;
        _rigidbody.velocity = diff.normalized * step;
    }

    private void StopPlayer()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void RotatePlayer(Vector3 targetPos)
    {
        var transform1 = transform;
        transform1.LookAt(targetPos);
        transform.rotation = Quaternion.Euler(0, transform1.eulerAngles.y, 0);
    }

    private float StopRange()
    {
        return mouseHandler.IsClickedOnObject ? _playerAttackRange.AttackRange : stopRange;
    }

    private void OnMouseRightClick()
    {
        _destination = mouseHandler.MousePosOnTerrain;
        if (mouseHandler.IsClickedOnObject)
        {
            _playerAutoAttack.AutoAttackInRange();
        }
    }
    
}
