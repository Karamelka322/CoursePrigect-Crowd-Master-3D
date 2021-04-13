using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovState : PlayerState
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedRation;

    private void OnEnable()
    {
        _playerInput.DirectionChanged += OnDirectionChange;
        _staminaAccumulator.StartAccumulate();
    }

    private void OnDisable()
    {
        _playerInput.DirectionChanged -= OnDirectionChange;
        Animator.SetFloat("run", 0);
    }

    private void OnDirectionChange(Vector2 direction)
    {
        Rigidbody.velocity = new Vector3(-direction.y, 0, direction.x) * _speedRation;

        if (Rigidbody.velocity.magnitude > _maxSpeed)
            Rigidbody.velocity *= _maxSpeed / Rigidbody.velocity.magnitude;

        if(Rigidbody.velocity.magnitude != 0)
            Rigidbody.MoveRotation(Quaternion.LookRotation(Rigidbody.velocity, Vector3.up));
    }

    private void Update()
    {
        Animator.SetFloat("run", Rigidbody.velocity.magnitude / _maxSpeed);
    }
}
