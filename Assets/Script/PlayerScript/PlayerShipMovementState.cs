using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerShipMovementState : PlayerBaseState
{
    public override void EnterState(PlayerController state)
    {
        _playerController = state;
        _playerController.Rigidbody.gravityScale = 0;
    }

    public override void UpdateState(PlayerController state)
    {
        ShipMovement();
        ShipMovementMaouseControl();
    }

    public override void ExitState(PlayerController state)
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

    private void ShipPositionUp()
    {
        Vector2 position = _playerController.transform.position + (Time.deltaTime * _playerController.ShipMovementSpeed * (Vector3.up * _playerController.JumpHeight));
        position.y = Mathf.Clamp(position.y, _playerController.MinY, _playerController.MaxY);
        _playerController.transform.position = position;
    }

    private void ShipPositionDown()
    {
        Vector2 position = _playerController.transform.position + (Time.deltaTime * _playerController.ShipMovementSpeed * (Vector3.down));
        position.y = Mathf.Clamp(position.y, _playerController.MinY, _playerController.MaxY);
        _playerController.transform.position = position;
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
        _playerController.transform.position = _playerController.ShipRespawnStartPosition;
    }


}
