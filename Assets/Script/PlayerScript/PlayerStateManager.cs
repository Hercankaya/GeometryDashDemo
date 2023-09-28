using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Speeds { Slow = 0, Normal = 1, Fast = 2 }
public class PlayerStateManager : MonoBehaviour
{   //State Machine deðiþkenleri
    public PlayerBaseState currentState;
    public PlayerVerticalMovement VerticalState = new PlayerVerticalMovement();
    public PlayerHorizontalMovements HorizontalState = new PlayerHorizontalMovements();
   
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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = HorizontalState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter2D(collision);

    }

}
