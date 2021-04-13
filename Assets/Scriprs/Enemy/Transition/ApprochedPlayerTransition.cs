using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprochedPlayerTransition : EnemyTransition
{
    [SerializeField] private float _approchedDistance;

    public override void Enable() { }

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < _approchedDistance)
            NeedTransit = true;
    }
}

