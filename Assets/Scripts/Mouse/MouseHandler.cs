using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    
    public Action OnMouseRightClick;
    
    private TerrainCollider _terrainCollider;
    private GameObject _player;
    private GameObject _selectedObject;
    public GameObject SelectedObject => _selectedObject;

    private GameObject _mouseHoweringObject;
    public GameObject MouseHoweringObject => _mouseHoweringObject;
    
    private Vector3 _mousePosOnTerrain;
    public Vector3 MousePosOnTerrain => _mousePosOnTerrain;
    
    private Ray _ray;
    private Camera _mCamera;
    
    private bool _clickedOnObject;
    public bool IsClickedOnObject => _clickedOnObject;

    private bool _rightClicked;
    public bool RightClicked => _rightClicked;
    
    private bool _isMouseOnObject;
    public bool IsMouseOnObject => _isMouseOnObject; 
    
    private void Start()
    {
        _terrainCollider = Terrain.activeTerrain.GetComponent<TerrainCollider>();
        _mCamera = Camera.main;
        _player = gameObject;
        _mousePosOnTerrain = _player.transform.position;
        _selectedObject = _player;
    }

    private void Update()
    {
        _ray = _mCamera.ScreenPointToRay(Input.mousePosition);
        MousePosOnObjectCheck();
        MousePosOnTerrainCheck();
    }
    
    private void MousePosOnTerrainCheck()
    {
        ClickTerrain();
    }
    private void ClickTerrain()
    {
        RaycastHit hitData;
        if (_terrainCollider.Raycast(_ray, out hitData, 1000))
        {
            _mousePosOnTerrain = hitData.point;
        }
    }
    
    private void MousePosOnObjectCheck()
    {
        RaycastHit hitData;
        if (Physics.Raycast(_ray, out hitData, Mathf.Infinity, layerMask))
        {
            _mouseHoweringObject = hitData.transform.gameObject;
            _isMouseOnObject = true;
        }
        else
        {
            _isMouseOnObject = false;
        }
    }
    
    private void SelectObject()
    {
        RaycastHit hitData;
        if (Physics.Raycast(_ray, out hitData, Mathf.Infinity, layerMask))
        {
            _selectedObject = hitData.transform.gameObject;
            _clickedOnObject = true; 
        }
        else
        {
            _clickedOnObject = false;
        }
    }
    
    public void RightClickDown()
    {
        _rightClicked = true;
        SelectObject();
        ClickTerrain();
        OnMouseRightClick?.Invoke();
    }

    public void RightClickUp()
    {
        _rightClicked = false;
    }
}
