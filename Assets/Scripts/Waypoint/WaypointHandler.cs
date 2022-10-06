using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointHandler : MonoBehaviour
{
    [SerializeField] private GameObject waypointPrefab;
    [SerializeField] private MouseHandler mouseHandler;
    
    private void Awake()
    {
        mouseHandler.OnMouseRightClick += OnMouseRightClick;
    }

    private void OnMouseRightClick()
    {
        var position = mouseHandler.MousePosOnTerrain + (Vector3.up / 5);
        var rotation = Quaternion.AngleAxis(90, Vector3.right);
        Instantiate(waypointPrefab, position, rotation);
    }
}
