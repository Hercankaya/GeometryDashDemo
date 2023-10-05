using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerCubeMovementState : PlayerBaseState
{
    public override void EnterState(PlayerController state)
    {
        _playerController = state;
        _playerController.Rigidbody.gravityScale = 10; 
    }

    public override void UpdateState(PlayerController state)
    {
        CubeMovement();
        Jump();
    }

    public override void ExitState(PlayerController state)
    {
      
    }

    private void CubeMovement()
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
            _playerController.Sprite.Rotate(Vector3.back * 250* Time.deltaTime);
        }
    }
    
    private bool OnGround()
    {
        float boxHeight = _playerController.transform.localScale.y;
        Vector3 boxCenter = _playerController.transform.position + Vector3.down * (boxHeight * 0.5f);
        Vector2 boxSize = new Vector2(1.1f, _playerController.GroundCheckRadius * 2);
        return Physics2D.OverlapBox(boxCenter, boxSize, 0, _playerController.GroundMask);
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


