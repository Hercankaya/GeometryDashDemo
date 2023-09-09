using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Speeds { Slow = 0 , Normal = 1 , Fast = 2 };

public class MovementController : MonoBehaviour
{

    public Speeds CurrentSpeed;
    float[] SpeedValues = { 10.0f, 20.0f, 30.0f };

    void Update()
    {
        transform.position += Vector3.right *SpeedValues[(int)CurrentSpeed] *Time.deltaTime;
        
    }

}
