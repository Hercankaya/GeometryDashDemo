using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{
    public float startingSpeed; 
    public float maximumSpeed; 
    private float speedIncreaseAmount = 3.0f; 
    public float currentSpeed;

    void Start()
    {
        currentSpeed = startingSpeed;
    }

    void Update()
    {
        if (currentSpeed < maximumSpeed)
        {
            currentSpeed += speedIncreaseAmount  * Time.deltaTime;
        }

        Vector3 movement = new Vector3(currentSpeed, 0, 0);
        transform.Translate(movement * Time.deltaTime);
    }

}
