using UnityEngine;
using UnityEngine.Events;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] private PlayerState _firstState;

    private PlayerState _currentState;

    public UnityAction Damaged;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody, _animator);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        PlayerState nextState = _currentState.GetNextState();

        if (nextState != null)
            Tansit(nextState);
    }

    private void Tansit(PlayerState nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if(_currentState != null)
            _currentState.Enter(_rigidbody, _animator);
    }

    public void ApplyDamage(float damage)
    {
        Damaged?.Invoke();
        _healthContainer.TakeDamage((int)damage);
    }

    public override void OnDied()
    {
        if (_currentState != null)
            _currentState.Exit();

        enabled = false;
        _animator.SetTrigger("broken");
    }
}
