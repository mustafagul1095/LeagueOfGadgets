using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QSkillBullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float destroyTime = 10f;
    
    private Vector3 _targetDir;
    private int _validEnemyLayer;

    public void Init(Vector3 targetPos)
    {
        _targetDir = (targetPos+(Vector3.up*5) - transform.position).normalized;
        StartCoroutine(QDestroy());
    }
    
    private void Update()
    {
        var delta = Time.deltaTime * speed;
        transform.position += _targetDir * delta;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _validEnemyLayer)
        {
            other.gameObject.GetComponentInParent<HealthHandler>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    public void SetValidEnemyLayer(int layerNum)
    {
        _validEnemyLayer = layerNum;
    }

    private IEnumerator QDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
