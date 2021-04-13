using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageble
{
    public bool ApplyDemage(Rigidbody rigidbody, float force)
    {
        return true;
    }
}
