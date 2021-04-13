using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAttackTransition : PlayerTransition
{
    [SerializeField] private AttackState _attackState;

    public override void Enable()
    {
        _attackState.AdilityEnded += OnAbilityEnded;
    }

    private void OnDisable()
    {
        _attackState.AdilityEnded -= OnAbilityEnded;        
    }

    private void OnAbilityEnded()
    {
        NeedTransit = true;
    }
}
