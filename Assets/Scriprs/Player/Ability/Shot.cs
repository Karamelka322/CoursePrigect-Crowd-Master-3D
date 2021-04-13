using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shot : MonoBehaviour
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Shooting(_rigidbody);
        Destroy(gameObject, _lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageble demageble))
            demageble.ApplyDemage(_rigidbody, _attackForce);
    }

    private void Shooting(Rigidbody rigidbody)
    {
        rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }
}
