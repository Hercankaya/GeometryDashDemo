using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public enum Speeds { Slow = 0, Normal = 1, Fast = 2 }
public class PlayerController : MonoBehaviour
{   
    public PlayerBaseState CurrentState;
    public PlayerShipMovementState ShipMovementState = new PlayerShipMovementState();
    public PlayerCubeMovementState CubeMovementState = new PlayerCubeMovementState();
    public float MinY = 0;
    public float MaxY = 1.50f;
    public float JumpHeight = 3.0f;
    public float ShipMovementSpeed = 3.0f;
    public float[] SpeedValues = { 5.0f, 10.0f, 15.0f };
    public Speeds CurrentSpeed;
    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    public Rigidbody2D Rigidbody;
    public Transform Sprite;
    public Vector2 CubeRespawnStartPosition;
    public Vector2 ShipRespawnStartPosition;


   private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        CubeMovementState.DestroyedEvent += OnCubeDestroyed;
        ShipMovementState.DestroyedEvent += OnShipDestroyed;
        CurrentState = CubeMovementState;
        CurrentState.EnterState(this);
    }

    private void OnDisable()
    {
        CubeMovementState.DestroyedEvent -= OnCubeDestroyed;
        ShipMovementState.DestroyedEvent -= OnShipDestroyed;
    }
    
    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LoginPortal"))
        {
            CurrentState.ExitState(this);
            CurrentState = ShipMovementState;
            CurrentState.EnterState(this);
        }
        else if (collision.gameObject.CompareTag("ExitPortal"))
        {
            CurrentState.ExitState(this);
            CurrentState = CubeMovementState;
            CurrentState.EnterState(this);
        }

        CurrentState.OnTriggerEnter2D(collision);
    }


    private void PlayDeathSound()
    {
        AudioManager.Instance.PlaySFX("DeathSound");
    }

    private void OnCubeDestroyed(object sender, EventArgs e)
    {
        PlayDeathSound();
        CubeMovementState.CubeRespawn();
    }

    private void OnShipDestroyed(object sender ,EventArgs e)
    {
        PlayDeathSound();
        ShipMovementState.ShipRespawn();

    }
}
