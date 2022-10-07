using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESkillBullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private GameObject damageAreaPrefab;
    
    private Vector3 _target;
    private int _validEnemyLayer;

    public void Init(Vector3 targetPos, int layerNum)
    {
        _target = targetPos;
        _validEnemyLayer = layerNum;
    }
    
    private void Update()
    {
        var delta = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, _target, delta);
        if (Vector3.Distance(transform.position, _target) <= delta)
        {
            ActivateDamageArea();
        }
    }
    
    private void ActivateDamageArea()
    {
        var go = Instantiate(damageAreaPrefab, transform.position, Quaternion.identity);
        go.GetComponent<SkillDamageArea>().Init(_validEnemyLayer);
        Destroy(gameObject);
    }
}
