using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Pool pool;
    public ObjectState objectState = ObjectState.Ready;
}


public enum ObjectState
{
    Ready,
    InUse
}