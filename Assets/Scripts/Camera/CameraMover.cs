using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float cameraXSpeed = 100f;
    [SerializeField] private float cameraZSpeed = 100f;
    [SerializeField] private float screenEdgeTreshold = 0.001f;
    
    
    [SerializeField] private Vector2 cameraSpeed = new(100f,100f);
    [SerializeField] private Vector3 minPositionLimit = new(150, 0,30);
    [SerializeField] private Vector3 maxPositionLimit = new(900, Mathf.Infinity, 920);
    
    void Update()
    {
        //MoveCameraWithKeyboard();
        MoveCameraWithMouse();
    }

    private void MoveCameraWithKeyboard()
    {
        var currentPosition = transform.position;
        
        currentPosition.x += Input.GetAxis("Horizontal") * cameraSpeed.x * Time.deltaTime;
        currentPosition.z += Input.GetAxis("Vertical") * cameraSpeed.y * Time.deltaTime;
        
        currentPosition = CheckPositionLimit(currentPosition);
        transform.position = currentPosition;
    }
    
    private void MoveCameraWithMouse()
    {
        var currentPosition = transform.position;
        
        float mouseRatioX = Input.mousePosition.x / Screen.width;
        float mouseRatioY = Input.mousePosition.y / Screen.height;
        
        if (mouseRatioX <= screenEdgeTreshold)
        {
            currentPosition.x -= cameraXSpeed * Time.deltaTime;
        }
        if (mouseRatioX >= 1-screenEdgeTreshold)
        {
            currentPosition.x += cameraXSpeed * Time.deltaTime;
        }
        if (mouseRatioY <= screenEdgeTreshold)
        {
            currentPosition.z -= cameraZSpeed * Time.deltaTime;
        }
        if (mouseRatioY >= 1-screenEdgeTreshold)
        {
            currentPosition.z += cameraZSpeed * Time.deltaTime;
        }
        
        currentPosition = CheckPositionLimit(currentPosition);
        transform.position = currentPosition;
    }

    private Vector3 CheckPositionLimit(Vector3 currentPos)
    {
        currentPos = Vector3.Max(currentPos,minPositionLimit);
        currentPos = Vector3.Min(currentPos,maxPositionLimit);
        return currentPos;
    }
}
