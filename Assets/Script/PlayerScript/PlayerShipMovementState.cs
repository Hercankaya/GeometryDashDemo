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
        VerticalMovement();
        Gravity();
    }

    public override void ExitState(PlayerController state)
    {

    }

    private void VerticalMovement()
    {
        _playerController.transform.position += Vector3.right * _playerController.ShipMovementSpeed * Time.deltaTime;
    }

    private void Gravity()
    {
        if (Input.GetMouseButton(0))
        {
            PlayerPositionUp();
        }
        else
        {
            PlayerPositionDown();
        }
    }

    private void PlayerPositionUp()
    {
        Vector2 position = _playerController.transform.position + (Time.deltaTime * _playerController.ShipMovementSpeed * (Vector3.up * _playerController.JumpHeight));
        position.y = Mathf.Clamp(position.y, _playerController.MinY, _playerController.MaxY);
        _playerController.transform.position = position;
    }

    private void PlayerPositionDown()
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
