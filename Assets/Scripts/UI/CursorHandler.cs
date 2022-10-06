using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    [SerializeField] private MouseHandler _mouseHandler;
    
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Texture2D moveToCursorTexture;
    [SerializeField] private Texture2D attackToCursorTexture;
    [SerializeField] private Texture2D enemyHoverCursorTexture;

    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotspot = Vector2.zero;
    
    private bool _cursorIsDefault;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, _hotspot, _cursorMode);
        _cursorIsDefault = true;
    }

    private void Update()
    {
        if (_mouseHandler.RightClicked && _mouseHandler.IsMouseOnObject)
        {
            Cursor.SetCursor(attackToCursorTexture, _hotspot, _cursorMode);
            _cursorIsDefault = false;
        }
        else if (_mouseHandler.RightClicked && !_mouseHandler.IsMouseOnObject)
        {
            Cursor.SetCursor(moveToCursorTexture, _hotspot, _cursorMode);
            _cursorIsDefault = false;
        }
        else if (!_mouseHandler.RightClicked && _mouseHandler.IsMouseOnObject)
        {
            Cursor.SetCursor(enemyHoverCursorTexture, _hotspot, _cursorMode);
            _cursorIsDefault = false;
        }
        else if (!_cursorIsDefault)
        {
            Cursor.SetCursor(cursorTexture, _hotspot, _cursorMode);
            _cursorIsDefault = true;
        }
    }
}
