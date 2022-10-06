using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float cameraXSpeed = 100f;
    [SerializeField] private float cameraZSpeed = 100f;
    [SerializeField] private float screenEdgeTreshold = 0.001f;
    [SerializeField] private float minXPos = -200f;
    [SerializeField] private float maxXPos = 200f;
    [SerializeField] private float minZPos = -200f;
    [SerializeField] private float maxZPos = 200f;
    [SerializeField] private Vector3 currentPos;
    
    void Update()
    {
        //MoveCameraWithKeyboard();
        MoveCameraWithMouse();
    }

    private void MoveCameraWithKeyboard()
    {
        currentPos = transform.position;
        
        currentPos.x += Input.GetAxis("Horizontal") * cameraXSpeed * Time.deltaTime;
        currentPos.z += Input.GetAxis("Vertical") * cameraZSpeed * Time.deltaTime;

        currentPos = CheckPositionLimit(currentPos);
        transform.position = currentPos;
    }
    
    private void MoveCameraWithMouse()
    {
        currentPos = transform.position;
        float deltaTime = Time.deltaTime;
        
        float mouseRatioX = Input.mousePosition.x / Screen.width;
        float mouseRatioY = Input.mousePosition.y / Screen.height;

        if (mouseRatioX <= screenEdgeTreshold)
        {
            currentPos.x -= cameraXSpeed * deltaTime;
        }
        if (mouseRatioX >= 1-screenEdgeTreshold)
        {
            currentPos.x += cameraXSpeed * deltaTime;
        }
        if (mouseRatioY <= screenEdgeTreshold)
        {
            currentPos.z -= cameraZSpeed * deltaTime;
        }
        if (mouseRatioY >= 1-screenEdgeTreshold)
        {
            currentPos.z += cameraZSpeed * deltaTime;
        }
        
        currentPos = CheckPositionLimit(currentPos);
        transform.position = currentPos;
    }

    private Vector3 CheckPositionLimit(Vector3 currentPos)
    {
        if (currentPos.x < minXPos)
        {
            currentPos.x = minXPos;
        }
        if (currentPos.x > maxXPos)
        {
            currentPos.x = maxXPos;
        }
        if (currentPos.z < minZPos)
        {
            currentPos.z = minZPos;
        }
        if (currentPos.z > maxZPos)
        {
            currentPos.z = maxZPos;
        }
        return currentPos;
    }
}
