using Cinemachine;
using UnityEngine;



public class CameraControllerScript : MonoBehaviour
{
    
    public Transform PlayerTarget;
    private float _smoothSpeed = 10f;
    public float SmoothSpeed => _smoothSpeed;
    private PlayerController _playerController;
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        

        if (virtualCamera == null)
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }
    }
    private void Update()
    {
        if (_playerController == null)
        {
            return;

        }
        if (_playerController .PlayerStatusCheck == false )
        {
            if (PlayerTarget == null)
            {
                return;
            }
            CameraXposition();

        }

        else if (_playerController.PlayerStatusCheck == true)
        {
            CameraXposition();
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = 2f;
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_SoftZoneHeight = 2f;
            virtualCamera.m_Lens.OrthographicSize =9;
        }
    }

    private void CameraXposition()
    {
        float desiredXPosition = PlayerTarget.position.x;
        float currentXPosition = transform.position.x;
        float smoothedXPosition = Mathf.Lerp(currentXPosition, desiredXPosition, _smoothSpeed);
        transform.position = new Vector3(smoothedXPosition, transform.position.y, transform.position.z);
      
    }

}

