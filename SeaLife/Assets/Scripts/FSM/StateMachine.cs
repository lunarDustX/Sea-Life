using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    public void Initialize(State _defaultState)
    {
        currentState = _defaultState;
        currentState.Enter();
    }

    public void ChangeState(State _newState)
    {
        //if (currentState != null)
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
