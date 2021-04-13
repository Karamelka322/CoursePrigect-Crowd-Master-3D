using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostPlayerTransition : EnemyTransition
{
    [SerializeField] private float _minimumLostDistance;

    public override void Enable() { }

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) > _minimumLostDistance)
            NeedTransit = true;
    }
}
