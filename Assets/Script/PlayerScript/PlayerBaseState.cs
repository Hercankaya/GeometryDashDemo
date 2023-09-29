using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerController stateManager;
    public abstract void EnterState(PlayerController state);
    public abstract void UpdateState(PlayerController state);
    public abstract void ExitState(PlayerController state);
    public abstract void OnTriggerEnter2D(Collider2D collision);

}