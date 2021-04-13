using UnityEngine;

public abstract class ImpactArea: MonoBehaviour
{
    [SerializeField] protected float _radius;

    public Collider[] SearchColliders()
    {
        Collider[] overlappedCilliders = Physics.OverlapSphere(transform.position, _radius);
        return overlappedCilliders;
    }
}
