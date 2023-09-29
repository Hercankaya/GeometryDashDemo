using UnityEngine;


public class PlayerShipMovementState : PlayerBaseState
{
    public override void EnterState(PlayerController state)
    {
        stateManager = state;
        stateManager.rb.gravityScale = 0;
     
        Debug.Log("PlayerVertical baþlatýldý.");

    }
    public override void UpdateState(PlayerController state)
    {
        Debug.Log("Player Vertical çalýþmaya devam ediyor");
        VerticalMovement();
        Gravity();
        


    }

    public override void ExitState(PlayerController state)
    {
        Debug.Log("PlayerVertical çalýþmayý bitirdi.");
    }


    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {

            
            stateManager.currentState.ExitState(stateManager);
            stateManager.currentState = stateManager.HorizontalState;
            stateManager.currentState.EnterState(stateManager);

        }
        if (collision.gameObject.CompareTag("VerticalObstacle"))
        {
            AudioManager.Instance.PlaySFX("DeathSound");
            VerticalRespawn();

        }
    }
    void VerticalMovement()
    {
         //stateManager.transform.position += Vector3.right * stateManager.SpeedValues[(int)stateManager.CurrentSpeed] * Time.deltaTime;
         stateManager.transform.position += Vector3.right * stateManager.VerticalMovementSpeed * Time.deltaTime;
    }

    public void Gravity()
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
    void PlayerPositionUp()
    {

        Vector2 position = stateManager.transform.position + (Time.deltaTime * stateManager.VerticalMovementSpeed * (Vector3.up * stateManager.JumpHeight));

        position.y = Mathf.Clamp(position.y, stateManager.MinY, stateManager.MaxY);

        stateManager.transform.position = position;
    }
    void PlayerPositionDown()
    {

        Vector2 position = stateManager.transform.position + (Time.deltaTime * stateManager.VerticalMovementSpeed * (Vector3.down));

        position.y = Mathf.Clamp(position.y, stateManager.MinY, stateManager.MaxY);

        stateManager.transform.position = position;
    }
    public void VerticalRespawn()
    {
        stateManager.transform.position = stateManager.VerticalRespawnStartPosition;
    }

}
