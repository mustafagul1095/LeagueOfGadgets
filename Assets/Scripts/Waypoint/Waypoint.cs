using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private float _timer = 0;
    
    public void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1)
        {
            Destroy(gameObject);
        }
    }
}
