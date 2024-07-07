using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
   public WolfStates currentState;

    void Update()
    {
        RunStateMachine();
    }


    private void RunStateMachine()
    {

        WolfStates nextState = currentState?.RunCurrentState();
        if(nextState!=null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(WolfStates nextState)
    {
        currentState = nextState;
    }

}
