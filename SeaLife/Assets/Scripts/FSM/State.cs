using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    protected StateMachine stateMachine;
    protected PlayerController playerController;

    protected State(PlayerController _playerController, StateMachine _stateMachine)
    {
        this.stateMachine = _stateMachine;
        this.playerController = _playerController;
    }

    public virtual void Enter()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
