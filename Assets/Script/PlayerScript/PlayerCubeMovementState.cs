using UnityEngine;


public class PlayerCubeMovementState : PlayerBaseState
{
    public override void EnterState(PlayerController state)
    {
        Debug.Log("PlayerHorizontal baþlatýldý.");
        stateManager = state;
        stateManager.rb.gravityScale = 15f;
    }
    public override void UpdateState(PlayerController state)
    {
       Debug.Log("PlayerHorizontal çalýþmaya devam ediyor");

        HorizontalMovement();
        Jump();
    }

    public override void ExitState(PlayerController state)
    {
        Debug.Log("PlayerHorizontal çalýþmayý bitirdi");
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
           
            stateManager.currentState.ExitState(stateManager);
            stateManager.currentState = stateManager.VerticalState;
            stateManager.currentState.EnterState(stateManager);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AudioManager.Instance.PlaySFX("DeathSound");
            Respawn();
        }
    }

    public void HorizontalMovement()
    {
        stateManager.transform.position += Vector3.right * stateManager.SpeedValues[(int)stateManager.CurrentSpeed] * Time.deltaTime;
    }

    void Jump()
    {
        if (OnGround())
        {
            Vector3 Rotation = stateManager.Sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            stateManager.Sprite.rotation = Quaternion.Euler(Rotation);

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

    bool OnGround()
    {
        return Physics2D.OverlapCircle(stateManager.GroundCheckTransform.position, stateManager.GroundCheckRadius, stateManager.GroundMask);
    }

    public void Respawn()
    {
        stateManager.transform.position = stateManager.RespawnStartPosition;
    }
}

