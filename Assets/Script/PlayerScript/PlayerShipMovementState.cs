using UnityEngine;

public class PlayerShipMovementState : PlayerBaseState
{
    public override void EnterState(PlayerController state)
    {
        stateManager = state;
        stateManager.rb.gravityScale = 0;
    }

    public override void UpdateState(PlayerController state)
    {
        VerticalMovement();
        Gravity();
    }

    public override void ExitState(PlayerController state)
    {
        // Çýkýþ 
    }

    private void VerticalMovement()
    {
        stateManager.transform.position += Vector3.right * stateManager.VerticalMovementSpeed * Time.deltaTime;
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
        Vector2 position = stateManager.transform.position + (Time.deltaTime * stateManager.VerticalMovementSpeed * (Vector3.up * stateManager.JumpHeight));
        position.y = Mathf.Clamp(position.y, stateManager.MinY, stateManager.MaxY);
        stateManager.transform.position = position;
    }

    private void PlayerPositionDown()
    {
        Vector2 position = stateManager.transform.position + (Time.deltaTime * stateManager.VerticalMovementSpeed * (Vector3.down));
        position.y = Mathf.Clamp(position.y, stateManager.MinY, stateManager.MaxY);
        stateManager.transform.position = position;
    }
}
