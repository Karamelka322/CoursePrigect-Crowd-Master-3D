using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaAccumulator : MonoBehaviour
{
    [SerializeField] private float _accumulationTime;
    [SerializeField] private Ability _ability;
    [SerializeField] private Ability _ultimateAbility;

    private float _staminaVlue;

    public void StartAccumulate()
    {
        _staminaVlue = 0;
    }
    private void Update()
    {
        _staminaVlue += Time.deltaTime;   
    }

    public Ability GetAdility()
    {
        if (_staminaVlue > _accumulationTime)
            return _ultimateAbility;

        return _ability;
    }
}
