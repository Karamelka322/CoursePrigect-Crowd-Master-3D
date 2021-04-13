using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Barrel : ImpactArea, IDamageble
{
    [SerializeField] private float _force;
    [SerializeField] private float _damage;

    private Rigidbody _rigidbody;
    private bool _isBarrelEnable;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public bool ApplyDemage(Rigidbody rigidbody, float force)
    {
        if (!_isBarrelEnable)
        {
            _isBarrelEnable = true;
            Explode();
        }

        return _isBarrelEnable;
    }

    private void Explode()
    {
        Collider[] colliders = SearchColliders();

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rigidbody = colliders[i].attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);

                if (rigidbody.TryGetComponent(out IDamageble damageble))
                {
                    damageble.ApplyDemage(_rigidbody, _damage);
                }
            }
        }

        _rigidbody.AddRelativeTorque(Vector3.right * _force, ForceMode.Impulse);
    }
}
