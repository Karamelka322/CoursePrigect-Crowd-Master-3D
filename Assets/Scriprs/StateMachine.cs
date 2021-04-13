using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(HealthContainer))]
public class StateMachine : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected Animator _animator;
    protected HealthContainer _healthContainer;

    public virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _healthContainer = GetComponent<HealthContainer>();
    }

    private void OnEnable()
    {
        _healthContainer.Died += OnDied;
    }

    private void OnDisable()
    {
        _healthContainer.Died -= OnDied;
    }

    public virtual void OnDied() { }
}
