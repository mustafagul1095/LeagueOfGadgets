using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    private Transform _target;
    public Transform Target => _target;

    public void Init(Transform target)
    {
        _target = target;
    }
    
    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
        }
    }

}
