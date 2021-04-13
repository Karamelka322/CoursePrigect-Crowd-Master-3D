using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State: MonoBehaviour
{
    public Rigidbody Rigidbody { get; protected set; }
    public Animator Animator { get; protected set; }
}
