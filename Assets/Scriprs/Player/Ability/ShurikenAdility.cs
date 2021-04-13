using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Shuriken Ability", menuName = "Player/Abilities/Shuriken", order = 51)]
public class ShurikenAdility : Ability
{
    [SerializeField] private Type _typeShuriken;
    [SerializeField] private float _attackDelay;
    [Space]
    [SerializeField] private Shot _shurikenPrefab;

    private enum Type { Standart, Ultimate };
    private readonly int _angle = 10;

    private AttackState _state;
    private Coroutine _coroutine;

    public override event UnityAction AbilityEnded;

    public override void UseAdility(AttackState attack)
    {
        if (_coroutine != null)
            return;

        _state = attack;
        _coroutine = _state.StartCoroutine(Attack(_state));
    }

    IEnumerator Attack(AttackState state)
    {
        state.Rigidbody.velocity = Vector3.zero;

        yield return new WaitForSeconds(_attackDelay);

        SpawnShuriken(state);

        _coroutine = null;
        AbilityEnded?.Invoke();
    }

    private void SpawnShuriken(AttackState state)
    {
        Vector3 derection = new Vector3(state.transform.position.x, 0, state.transform.position.z);
        Quaternion rotation = state.transform.rotation;

        switch (_typeShuriken)
        {
            case Type.Standart:
                Instantiate(_shurikenPrefab, derection, rotation);
                break;

            case Type.Ultimate:
                Instantiate(_shurikenPrefab, derection, rotation);
                Instantiate(_shurikenPrefab, derection, rotation).transform.Rotate(0, rotation.y + _angle, 0);
                Instantiate(_shurikenPrefab, derection, rotation).transform.Rotate(0, rotation.y - _angle, 0);
                break;
        }
    }
}
