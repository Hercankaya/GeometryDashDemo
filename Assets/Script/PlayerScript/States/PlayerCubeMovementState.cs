using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCubeMovementState : PlayerBaseState
{
    public override void EnterState(PlayerController state)
    {
        _playerController = state;
        _playerController.Rigidbody.gravityScale = 15;
        AddEvents();
    }
    private void AddEvents()
    {
       

    }

    private void RemoveEvents()
    {
      

    }
    public override void UpdateState(PlayerController state)
    {
        CubeMovement();
        Jump();
        
    }

    public override void ExitState(PlayerController state)
    {
        RemoveEvents();
    }
    private void CubeMovement()
    {
        if(_playerController.PlayerLive == true) 
        {
            _playerController.transform.position += (Vector3.right * _playerController.CurrentSpeed) * Time.deltaTime;
            LineMovement();
        }
        else if (_playerController.PlayerLive == false)
        {
            _playerController.transform.position = _playerController.transform.position;
            _playerController.DeathParticles.Play();
        }
      
    }

    private void Jump()
    {
        if (OnGround())
        {
            Vector3 rotation = _playerController.SpriteTransform.rotation.eulerAngles;
            rotation.z = Mathf.Round(rotation.z / 180) * 180;
            _playerController.SpriteTransform.rotation = Quaternion.Euler(rotation);

            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                _playerController.Rigidbody.velocity = Vector2.zero;
                _playerController.Rigidbody.AddForce(Vector2.up *30.0f, ForceMode2D.Impulse);
            }
        }
        else
        {
            _playerController.SpriteTransform.Rotate(Vector3.back * 450* Time.deltaTime);
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
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _playerController.transform.position = _playerController.CubeRespawnStartPosition;
        _playerController.transform.rotation = Quaternion.identity;
        
    }
    private void LineMovement()
    {
        Vector2 newLightPosition = _playerController.GroundLightTransform.position;
        newLightPosition.x = _playerController.transform.position.x + 1.70f;
        _playerController.GroundLightTransform.position = newLightPosition;

    }
    
}


