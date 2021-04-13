using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    [SerializeField] private PlayerTransition[] _transitions;

    public void Enter(Rigidbody rigidbody, Animator animator)
    {
        if (!enabled)
        {
            Rigidbody = rigidbody;
            Animator = animator;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            enabled = false;

            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
        }
    }

    public PlayerState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
