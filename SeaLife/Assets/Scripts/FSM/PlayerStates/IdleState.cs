using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private float hInput, vInput;

    public IdleState(PlayerController _playerController, StateMachine _stateMachine) : base(_playerController, _stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (hInput != 0 || vInput != 0)
        {
            stateMachine.ChangeState(playerController.walkState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


}
