using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Hand Adility", menuName = "Player/Abilities/Hand", order = 51)]
public class HandAdility : Ability
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _usefullTime;

    private AttackState _state;
    private Coroutine _coroutine;

    public override event UnityAction AbilityEnded;

    public override void UseAdility(AttackState attack)
    {
        if (_coroutine != null)
            Reset();

        _state = attack;

        _coroutine = _state.StartCoroutine(Attack(_state));
        _state.CollisionDetcted += OnPlayerAttack;
    }

    private void OnPlayerAttack(IDamageble demageble)
    {
        if (demageble.ApplyDemage(_state.Rigidbody, _attackForce) == false)
            return;

        _state.Rigidbody.velocity /= 2;
    }

    IEnumerator Attack(AttackState state)
    {
        float time = _usefullTime;

        while(time > 0)
        {
            state.Rigidbody.velocity = state.Rigidbody.velocity.normalized * _attackForce;
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Reset();
        AbilityEnded?.Invoke();
    }

    private void Reset()
    {
        _state.Rigidbody.velocity = Vector3.zero;
        _state.StopCoroutine(_coroutine);
        _coroutine = null;
        _state.CollisionDetcted -= OnPlayerAttack;
    }
}
