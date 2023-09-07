using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingController : MonoBehaviour
{

    public float jumpForce = 10f; 
    private bool canJump = true; 
    private float currentSpeed;

    private void Update()
    {
        Vector2 movement = new Vector2(currentSpeed, 0);
        transform.Translate(movement * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && canJump)
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

        canJump = false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
    
}
