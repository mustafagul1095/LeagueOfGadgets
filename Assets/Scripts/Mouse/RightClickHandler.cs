using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickHandler : MonoBehaviour
{
    private MouseHandler _mouseHandler;

    private void Start()
    {
        _mouseHandler = GetComponent<MouseHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _mouseHandler.RightClickDown();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _mouseHandler.RightClickUp();
        }
    }
    

}
