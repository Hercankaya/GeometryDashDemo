using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Speeds { Slow = 0, Normal = 1, Fast = 2 };
public class PlayerController : MonoBehaviour
{
    public Speeds CurrentSpeed;
    float[] SpeedValues = { 10.0f, 20.0f, 30.0f };
    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    Rigidbody2D rb;
    public Transform Sprite;
    Vector2 StartPosition;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       StartPosition = transform.position;
    }

   
    void Update()
    {
        HorizontalMovement();
        Jump();
    }

    void HorizontalMovement()
    {
        transform.position += Vector3.right * SpeedValues[(int)CurrentSpeed] * Time.deltaTime;
    }
    
   
   
    void Jump()
    {
        if (OnGround())
        {
            Vector3 Rotation = Sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            Sprite.rotation = Quaternion.Euler(Rotation);

            if (Input.GetMouseButton(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 25.0f, ForceMode2D.Impulse);
            }
        }
        else
        {
            Sprite.Rotate(Vector3.back * 450 * Time.deltaTime);
        }
    }

    bool OnGround()
    {
        return Physics2D.OverlapCircle(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            AudioManager.Instance.PlaySFX("DeathSound");
            Respawn();
        }
        
    }

    public void Respawn()
    {
       
        transform.position = StartPosition;
    }


  

}
