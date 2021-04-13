using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : State
{
    [SerializeField] private EnemyTransition[] _transitions;

    public PlayerStateMachine Player { get; private set; }

    public void Enter(Rigidbody rigidbody, Animator animator, PlayerStateMachine player)
    {
        if (!enabled)
        {
            Rigidbody = rigidbody;
            Animator = animator;
            Player = player;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Player);
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

    public EnemyState GetNextState()
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

