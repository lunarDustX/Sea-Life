using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimState : State
{
    private float hInput, vInput;
    private float spd;

    public SwimState(PlayerController _playerController, StateMachine _stateMachine) : base(_playerController, _stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        hInput = vInput = 0;
        spd = playerController.swimSpd;
        playerController.SetAnimationBool(playerController.swimmingParam, true);
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

        // TODO:swimIdle
        if (playerController.inWater == false)
        {
            stateMachine.ChangeState(playerController.walkState);
            return;
        }

        playerController.Breathe();
        playerController.Move(hInput, vInput, spd);

    }

    public override void Exit()
    {
        base.Exit();

        playerController.ResetOxygen();
        playerController.SetAnimationBool(playerController.swimmingParam, false);
    }
}
