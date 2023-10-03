using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerCubeMovementState : PlayerBaseState
{
    
    public override void EnterState(PlayerController state)
    {
        _playerController = state;
        _playerController.Rigidbody.gravityScale = 15f;
    }

    public override void UpdateState(PlayerController state)
    {
        HorizontalMovement();
        Jump();
    }

    public override void ExitState(PlayerController state)
    {
      
    }

    private void HorizontalMovement()
    {
        _playerController.transform.position += Vector3.right * _playerController.SpeedValues[(int)_playerController.CurrentSpeed] * Time.deltaTime;
    }

    private void Jump()
    {
        if (OnGround())
        {
            Vector3 rotation = _playerController.Sprite.rotation.eulerAngles;
            rotation.z = Mathf.Round(rotation.z / 90) * 90;
            _playerController.Sprite.rotation = Quaternion.Euler(rotation);

            if (Input.GetMouseButton(0))
            {
                _playerController.Rigidbody.velocity = Vector2.zero;
                _playerController.Rigidbody.AddForce(Vector2.up * 25.0f, ForceMode2D.Impulse);
            }
        }
        else
        {
            _playerController.Sprite.Rotate(Vector3.back * 450 * Time.deltaTime);
        }
    }

    private bool OnGround()
    {
        return Physics2D.OverlapCircle(_playerController.GroundCheckTransform.position, _playerController.GroundCheckRadius, _playerController.GroundMask);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        
         if (collision.gameObject.CompareTag("CubeObstacle"))
        {
            DestroyedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
    public void CubeRespawn()
    {
        _playerController.transform.position = _playerController.CubeRespawnStartPosition;
    }
}


