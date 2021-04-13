using UnityEngine;
using UnityEngine.Events;

public class EnemyStateMachine : StateMachine, IDamageble
{
    [SerializeField] private EnemyState _firstState;
    [SerializeField] private BrokenState _brokenState;

    private EnemyState _cuttentState;
    private float _minDamage;

    public PlayerStateMachine Player { get; private set; }
    public event UnityAction<StateMachine> Died;

    public override void Awake()
    {
        base.Awake();
        Player = FindObjectOfType<PlayerStateMachine>();
    }

    private void Start()
    {
        _cuttentState = _firstState;
        _cuttentState.Enter(_rigidbody, _animator, Player);
    }

    private void Update()
    {
        if (_cuttentState == null)
            return;

        EnemyState nextState = _cuttentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    public override void OnDied()
    {
        enabled = false;
        _rigidbody.constraints = RigidbodyConstraints.None;
        Died?.Invoke(this);
    }

    private void Transit(EnemyState nextState)
    {
        if (_cuttentState != null)
            _cuttentState.Exit();

        _cuttentState = nextState;

        if (_cuttentState != null)
            _cuttentState.Enter(_rigidbody, _animator, Player);
    }

    public bool ApplyDemage(Rigidbody rigidbody, float force)
    {
        if(force > _minDamage && _cuttentState != _brokenState)
        {
            _healthContainer.TakeDamage((int)force);
            Transit(_brokenState);
            _brokenState.ApplayDamage(rigidbody, force);

            return true;
        }

        return false;
    }
}
