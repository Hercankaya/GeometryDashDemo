using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
 
    public float MinY;
    public float MaxY;
    [SerializeField] float JumpHeight = 5;
    [SerializeField] float gravityScale = 5;
    [SerializeField] float VerticalMovementSpeed;
    public Vector2 StartPosition;


    void Start()
    {
        
    }

    
    void Update()
    {

        transform.position += Vector3.right * VerticalMovementSpeed * Time.deltaTime;
        Gravity();
    }

     void Gravity()
    {

        if (Input.GetMouseButton(0))
        {
            PlayerPositionUp();
        }
        else
        {
            PlayerPositionDown();
        }

    }

    void PlayerPositionUp()
    {

        Vector2 position = transform.position + (Time.deltaTime * VerticalMovementSpeed * (Vector3.up * JumpHeight));

        position.y = Mathf.Clamp(position.y, MinY, MaxY);

        transform.position = position;
    }
    void PlayerPositionDown()
    {

        Vector2 position = transform.position + (Time.deltaTime * VerticalMovementSpeed * (Vector3.down ));

        position.y = Mathf.Clamp(position.y, MinY, MaxY);

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Respawn();
        }

    }

    public void Respawn()
    {
        AudioManager.Instance.PlaySFX("DeathSound");
        transform.position = StartPosition;
    }

}
