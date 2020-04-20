using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Target
{
    public Transform transform;
    public Vector3 lastPos;
    public bool IsInRange;

    public void InitLastPos()
    {
        lastPos = transform.position;
    }
    public void InRange()
    {
        IsInRange = true;
    }
    public void OutOfRange()
    {
        IsInRange = false;
    }
    public bool IsMoving
    {
        get { return lastPos != transform.position; }
    }
}
