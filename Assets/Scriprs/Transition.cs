using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    public bool NeedTransit { get; protected set; }

    protected void OnEnable()
    {
        NeedTransit = false;
        Enable();
    }

    public abstract void Enable();
}
