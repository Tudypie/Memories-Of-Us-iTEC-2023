using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    enum State {Grounded, InAir, Crouching}

    State currentState = State.Grounded;

    private void Start()
    {
        currentState = State.Grounded;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        switch(currentState)
        {
            case State.Grounded:
                currentState = State.InAir;
                break;
            case State.Crouching:
                currentState = State.Grounded;
                break;
        }
    }
}


