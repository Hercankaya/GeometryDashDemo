using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class CameraControllerScript : MonoBehaviour
{
   
    public Transform PlayerTarget;
    public float SmoothSpeed;
    void LateUpdate()
    {
        if (PlayerTarget == null)
        {
            return;
        }

        float desiredXPosition = PlayerTarget.position.x;
        float currentXPosition = transform.position.x;
        float smoothedXPosition = Mathf.Lerp(currentXPosition, desiredXPosition, SmoothSpeed);
        transform.position = new Vector3(smoothedXPosition, transform.position.y, transform.position.z);
 
    }
    
}

