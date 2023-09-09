using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingController : MonoBehaviour
{
    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    Rigidbody2D rb;
    public Transform Sprite;
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     void Update()
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


}
