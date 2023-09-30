using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public enum Speeds { Slow = 0, Normal = 1, Fast = 2 }
public class PlayerController : MonoBehaviour
{   
    public PlayerBaseState currentState;
    public PlayerShipMovementState VerticalState = new PlayerShipMovementState();
    public PlayerCubeMovementState HorizontalState = new PlayerCubeMovementState();
   
    public float MinY = 0;
    public float MaxY = 1.50f;
    public float JumpHeight = 3.0f;
    public float VerticalMovementSpeed = 3.0f;
    
    public float[] SpeedValues = { 5.0f, 10.0f, 15.0f };
    public Speeds CurrentSpeed;

    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    public Rigidbody2D rb;
    public Transform Sprite;
    
    public Transform playerTransform;
    public Vector2 RespawnStartPosition;
    public Vector2 VerticalRespawnStartPosition;


   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = HorizontalState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LoginPortal"))
        {
            currentState.ExitState(this);
            currentState = VerticalState;
            currentState.EnterState(this);
        }
        else if (collision.gameObject.CompareTag("ExitPortal"))
        {
            currentState.ExitState(this);
            currentState = HorizontalState;
            currentState.EnterState(this);
        }
        else if (collision.gameObject.CompareTag("HorizontalObstacle"))
        {
            HandleHorizontalObstacleCollision();
        }
        else if (collision.gameObject.CompareTag("VerticalGround") || collision.gameObject.CompareTag("VerticalObstacle"))
        {
            HandleVerticalCollision();
        }
    }

    private void HandleHorizontalObstacleCollision()
    {
        HorizontalRespawn();
        PlayDeathSound();
    }

    private void HandleVerticalCollision()
    {
        PlayDeathSound();
        VerticalRespawn();
    }


    private void PlayDeathSound()
    {
        AudioManager.Instance.PlaySFX("DeathSound");
    }

    private void HorizontalRespawn()
    {
        transform.position = RespawnStartPosition;
    }
    private void VerticalRespawn()
    {
       transform.position = VerticalRespawnStartPosition;
    }
   
}
