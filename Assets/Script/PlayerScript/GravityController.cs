using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float jumpForce = 10f;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

}
