using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    public State currentState;

    private void Start()
    {
        if(currentState != null)
        {
            currentState.OnStart();
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if(currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    private void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.OnLateUpdate();
        }
    }

    public void SetNewState(State state)
    {
        if(state != null)
        {
            currentState = state;
            currentState.OnStart();
        }

    }
}
