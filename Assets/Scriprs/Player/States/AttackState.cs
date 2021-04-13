using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : PlayerState
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;

    private Ability _currentAbility;

    public event UnityAction<IDamageble> CollisionDetcted;
    public event UnityAction AdilityEnded;

    private void OnEnable()
    {
        Animator.SetTrigger("attack");
        _currentAbility = _staminaAccumulator.GetAdility();
        _currentAbility.AbilityEnded += OnAdilityEnded;

        _currentAbility.UseAdility(this);
    }

    private void OnDisable()
    {
        _currentAbility.AbilityEnded -= OnAdilityEnded;
    }

    private void OnAdilityEnded()
    {
        AdilityEnded?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageble demageble))
            CollisionDetcted?.Invoke(demageble);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageble demageble))
            CollisionDetcted?.Invoke(demageble);
    }
}
