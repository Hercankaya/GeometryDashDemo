using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class PlayerShipMovementState : PlayerBaseState
{
    public override void EnterState(PlayerController state)
    {
        _playerController = state;
        _playerController.transform.rotation = Quaternion.identity;
        _playerController.Rigidbody.gravityScale = 0;
        AddEvents();

    }

    public override void UpdateState(PlayerController state)
    {
         ShipMovement();
         ShipMovementMaouseControl();
        

    }

    public override void ExitState(PlayerController state)
    {
        RemoveEvents();
    }
    private void AddEvents()
    {
     
    }

    private void RemoveEvents()
    {
       
    }
    
    private void ShipMovement()
    {
        _playerController.transform.position += Vector3.right * _playerController.ShipMovementSpeed * Time.deltaTime;
        
    }
    
    private void ShipMovementMaouseControl()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            _playerController.Rigidbody.gravityScale = -3;
        }
        else
        {
            _playerController.Rigidbody.gravityScale = 3;
        }
        var targetRotation = Quaternion.Euler(0, 0, _playerController.Rigidbody.velocity.y * 2);
        _playerController.transform.localRotation = Quaternion.Slerp(_playerController.transform.localRotation, targetRotation, Time.deltaTime * 6);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShipObstacle") || collision.gameObject.CompareTag("ShipGround"))
        {
            DestroyedEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    public void ShipRespawn()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _playerController.transform.position = _playerController.ShipRespawnStartPosition;
        _playerController.transform.rotation = Quaternion.identity;
    }

}
