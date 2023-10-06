using System;
using UnityEngine;

public abstract class PlayerBaseState
{
    public  EventHandler DestroyedEvent;

    protected PlayerController _playerController;

    public abstract void EnterState(PlayerController playerController);
    public abstract void UpdateState(PlayerController playerController);
    public abstract void ExitState(PlayerController playerController);

    public abstract void OnTriggerEnter2D(Collider2D collision);
}
