using UnityEngine;



public class CameraControllerScript : MonoBehaviour
{
    
    public Transform PlayerTarget;

    private float _smoothSpeed = 10f;
    public float SmoothSpeed => _smoothSpeed;
     
     void LateUpdate()
     {
         if (PlayerTarget == null)
         {
             return;
         }
         float desiredXPosition = PlayerTarget.position.x;
         float currentXPosition = transform.position.x;
         float smoothedXPosition = Mathf.Lerp(currentXPosition, desiredXPosition, _smoothSpeed);
         transform.position = new Vector3(smoothedXPosition, transform.position.y, transform.position.z);

     }
    
}

