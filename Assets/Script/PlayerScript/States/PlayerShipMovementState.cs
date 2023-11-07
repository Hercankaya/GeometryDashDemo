using System;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        if (Input.GetMouseButton(0))
        {
            ShipPositionUp();
        }
        else
        {
            ShipPositionDown();
        }
    }

    private void MoveShip(Vector3 direction)
    {
        Vector2 position = _playerController.transform.position + (Time.deltaTime * _playerController.ShipMovementSpeed * direction);
        _playerController.transform.position = position;
    }

    private void ShipPositionUp()
    {
        Vector3 upDirection = Vector3.up * _playerController.JumpHeight;
        MoveShip(upDirection);
    }

    private void ShipPositionDown()
    {
        Vector3 downDirection = Vector3.down;
        MoveShip(downDirection);
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
