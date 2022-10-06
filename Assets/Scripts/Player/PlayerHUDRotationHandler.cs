using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUDRotationHandler : MonoBehaviour
{
    private Quaternion _rotation;
    private Camera _camera;
    private Transform _cameraTransform;

    private void Start()
    {
        _camera = Camera.main;
        if (_camera != null) _cameraTransform = _camera.GetComponent<Transform>();
    }
    
    private void LateUpdate()
    {
        transform.rotation = _cameraTransform.rotation;
    }
}
