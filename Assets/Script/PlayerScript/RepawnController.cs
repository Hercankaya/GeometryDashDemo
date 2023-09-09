using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepawnController : MonoBehaviour
{
    Vector2 StartPosition;

    private void Start()
    {
        StartPosition = transform.position;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Obstacle"))
        {
            Respawn();
        }

    }
    void Respawn()
    {
        transform.position = StartPosition;
    }
   

}
