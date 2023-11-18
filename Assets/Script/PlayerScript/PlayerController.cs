using System;
using UnityEngine;

[Serializable]
public class PlayerTransformData
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}


public class PlayerController : MonoBehaviour
{
   
    public PlayerBaseState _currentState;
    public PlayerShipMovementState ShipMovementState = new PlayerShipMovementState();
    public PlayerCubeMovementState CubeMovementState = new PlayerCubeMovementState();
    private float _shipMovementSpeed = 10f;
    public float ShipMovementSpeed =>_shipMovementSpeed;
    private float _groundCheckRadius =0.05f;
    public float JumpHeight =>_jumpHeight;
    private float _jumpHeight = 0.3f;
    public float GroundCheckRadius => _groundCheckRadius;
    private float _currentSpeed = 15.0f;
    public  float CurrentSpeed => _currentSpeed;
    public LayerMask GroundMask;
    public Vector2 CubeRespawnStartPosition;
    public Vector2 ShipRespawnStartPosition;
    public bool IsChangeSprite { get => _changeSprite; set => _changeSprite = value;}
    private bool _changeSprite = false;
    private Vector3 _firstSpriteScaleValue;
    private SpriteRenderer _spriteRenderer;
    private Sprite _playerCubeSprite, _playerShipSprite;
    private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody=>_rigidbody;
    private Transform _groundCheckTransform;
    public Transform GroundCheckTransform => _groundCheckTransform;
    private Transform _spriteTransform;
    public Transform SpriteTransform => _spriteTransform;
    private bool _playerLive = true;
    public bool PlayerLive
    {
        get {
                return _playerLive;

            }

        set {
                _playerLive = value;

            }
    }

    public Transform GroundLightTransform;
    public bool PlayerStatusCheck => _playerStatusCheck;
    private bool _playerStatusCheck = false;
    private void Start()
    {
       
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentState = CubeMovementState;
        _currentState.EnterState(this);
        EventsOnPlayerDestroyed();
        SpriteOperations();
        GroundCheckOperations();

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
        _playerLive = false;
    }

    private void OnShipDestroyed(object sender ,EventArgs e)
    {
        PlayDeathSound();
        ShipMovementState.ShipRespawn();
        _playerLive = false;

    }

    private void SpriteOperations()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _playerCubeSprite = Resources.Load<Sprite>("Sprites/PlayerSprites/CubePlayerSprite");
        _playerShipSprite = Resources.Load<Sprite>("Sprites/PlayerSprites/ShipPlayerSprite");
        _spriteRenderer.sprite = _playerCubeSprite;
        _spriteTransform = _spriteRenderer.transform;
    }
    private void GroundCheckOperations()
    {
        _groundCheckTransform = transform.Find("GroundCheck");
    }

    private void ChangeSprite()
    {
        if(_changeSprite )
        {
            _firstSpriteScaleValue = _spriteRenderer.transform.localScale;
            _spriteRenderer.sprite = _playerShipSprite;
            _spriteTransform.transform.rotation= Quaternion.identity;
            
        }
        else 
        {
            _spriteRenderer.transform.localScale = _firstSpriteScaleValue;
            _spriteRenderer.sprite = _playerCubeSprite;
           
        }
    }

    public void PortalEnter()
    {
        var isCurrentStateCubeMovement = _currentState == CubeMovementState;
        _currentState.ExitState(this);
        _currentState = isCurrentStateCubeMovement ? ShipMovementState : CubeMovementState;
        _playerStatusCheck = isCurrentStateCubeMovement;
        _currentState.EnterState(this);
        IsChangeSprite = isCurrentStateCubeMovement;
        ChangeSprite();
        

    }

}
