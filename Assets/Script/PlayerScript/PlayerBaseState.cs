using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateManager stateManager;
    public abstract void EnterState(PlayerStateManager state);
    public abstract void UpdateState(PlayerStateManager state);
    public abstract void ExitState(PlayerStateManager state);
    public abstract void OnTriggerEnter2D(Collider2D collision);

}