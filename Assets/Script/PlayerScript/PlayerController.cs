using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
   
    private PlayerBaseState _currentState;
    private PlayerShipMovementState ShipMovementState = new PlayerShipMovementState();
    private PlayerCubeMovementState CubeMovementState = new PlayerCubeMovementState();

    private float _jumpHeight = 3.0f;
    public float JumpHeight => _jumpHeight;

    private float _shipMovementSpeed = 3.0f;
    public float ShipMovementSpeed =>_shipMovementSpeed;

    private float _groundCheckRadius =2.0f;
    public float GroundCheckRadius => _groundCheckRadius;

    private float _currentSpeed = 10.0f;
    public  float CurrentSpeed => _currentSpeed;
    
    public LayerMask GroundMask;
    public Vector2 CubeRespawnStartPosition;
    public Vector2 ShipRespawnStartPosition;
   
    private bool _changeSprite = false;
    private Vector3 _firstSpriteScaleValue;
    private SpriteRenderer _spriteRenderer;
    private Sprite _playerCubeSprite, _playerShipSprite;

    internal Rigidbody2D Rigidbody;
    internal Transform spriteTransform;

    private void Start()
    {
        spriteTransform = GetComponent<Transform>();
        Rigidbody = GetComponent<Rigidbody2D>();
        _currentState = CubeMovementState;
        _currentState.EnterState(this);
        EventsOnPlayerDestroyed();
        SpriteOperations();

    }
    private void Update()
    {
        _currentState.UpdateState(this);
    }

    private void EventsOnPlayerDestroyed()
    {
        CubeMovementState.DestroyedEvent += OnCubeDestroyed;
        ShipMovementState.DestroyedEvent += OnShipDestroyed;
    }
    private void OnDisable()
    {
        CubeMovementState.DestroyedEvent -= OnCubeDestroyed;
        ShipMovementState.DestroyedEvent -= OnShipDestroyed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LoginPortal"))
        {
            _currentState.ExitState(this);
            _currentState = ShipMovementState;
            _currentState.EnterState(this);
            _changeSprite = true;
            ChangeSprite();

        }
        else if (collision.gameObject.CompareTag("ExitPortal"))
        {
            _currentState.ExitState(this);
            _currentState = CubeMovementState;
            _currentState.EnterState(this);
            _changeSprite = false;
            ChangeSprite();
           
        }

        _currentState.OnTriggerEnter2D(collision);
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

    private void SpriteOperations()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _playerCubeSprite = Resources.Load<Sprite>("Sprites/CubePlayerSprite");
        _playerShipSprite = Resources.Load<Sprite>("Sprites/ShipPlayerSprite");
        _spriteRenderer.sprite = _playerCubeSprite;

    }


    
    private void ChangeSprite()
    {
        if(_changeSprite == true)
        {
            _firstSpriteScaleValue = _spriteRenderer.transform.localScale;
            _spriteRenderer.sprite = _playerShipSprite;
            _spriteRenderer.transform.localScale *= 0.5f;
            
 
            
        }
        else if (_changeSprite==false)
        {
            _spriteRenderer.transform.localScale = _firstSpriteScaleValue;
            _spriteRenderer.sprite = _playerCubeSprite;
        }
    }


}
