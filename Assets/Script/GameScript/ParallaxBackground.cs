using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    private float _offset;
    private Material _material;
    private CameraControllerScript _cameraControllerScript;

    void Start()
    {
        _material = GetComponent<Renderer>().material;   
        _cameraControllerScript = FindObjectOfType<CameraControllerScript>();
    }
    void Update()
    {
        if (_cameraControllerScript != null)
        {
            float smoothSpeed = _cameraControllerScript.SmoothSpeed;
            _offset += (Time.deltaTime * smoothSpeed) / 50f;
            _material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
        }
        
    }
}
