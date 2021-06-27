using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    private float hInput, vInput;
    private float spd;

    public WalkState(PlayerController _playerController, StateMachine _stateMachine) : base(_playerController, _stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        hInput = vInput = 0;
        spd = playerController.walkSpd;
        playerController.SetAnimationBool(playerController.walkingParam, true);
        //Debug.Log("Walk State Enter");
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

        if (hInput == 0 && vInput == 0)
        {
            stateMachine.ChangeState(playerController.idleState);
            return;
        }

        if (playerController.inWater == true)
        {
            stateMachine.ChangeState(playerController.swimState);
            return;
        }
        
        playerController.Move(hInput, vInput, spd);
    }

    public override void Exit()
    {
        base.Exit();
        playerController.SetAnimationBool(playerController.walkingParam, false);
        //Debug.Log("Walk State Exit");
    }
}
