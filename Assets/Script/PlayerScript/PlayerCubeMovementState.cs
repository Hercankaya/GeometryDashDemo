using UnityEngine;

public class PlayerCubeMovementState : PlayerBaseState
{
    public override void EnterState(PlayerController state)
    {
        stateManager = state;
        stateManager.rb.gravityScale = 15f;
    }

    public override void UpdateState(PlayerController state)
    {
        HorizontalMovement();
        Jump();
    }

    public override void ExitState(PlayerController state)
    {
        // Çýkýþ 
    }

    private void HorizontalMovement()
    {
        stateManager.transform.position += Vector3.right * stateManager.SpeedValues[(int)stateManager.CurrentSpeed] * Time.deltaTime;
    }

    private void Jump()
    {
        if (OnGround())
        {
            Vector3 rotation = stateManager.Sprite.rotation.eulerAngles;
            rotation.z = Mathf.Round(rotation.z / 90) * 90;
            stateManager.Sprite.rotation = Quaternion.Euler(rotation);

            if (Input.GetMouseButton(0))
            {
                stateManager.rb.velocity = Vector2.zero;
                stateManager.rb.AddForce(Vector2.up * 25.0f, ForceMode2D.Impulse);
            }
        }
        else
        {
            stateManager.Sprite.Rotate(Vector3.back * 450 * Time.deltaTime);
        }
    }

    private bool OnGround()
    {
        return Physics2D.OverlapCircle(stateManager.GroundCheckTransform.position, stateManager.GroundCheckRadius, stateManager.GroundMask);
    }
}


