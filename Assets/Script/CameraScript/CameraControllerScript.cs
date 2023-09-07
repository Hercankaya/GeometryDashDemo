using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControllerScript : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        float desiredXPosition = target.position.x;
        float currentXPosition = transform.position.x;
        float smoothedXPosition = Mathf.Lerp(currentXPosition, desiredXPosition, smoothSpeed);

        transform.position = new Vector3(smoothedXPosition, transform.position.y, transform.position.z);
    }

}

