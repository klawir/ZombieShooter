using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Target
{
    private Transform transform;
    private Player player;
    private Vector3 lastPos;
    private bool isInRange;

    public void Init(Player player)
    {
        this.player = player;
        transform = player.transform;
    }

    public Player Player => player;

    public Transform Transform => transform;

    public Vector3 Position => transform.position;

    public void InitLastPos()
    {
        lastPos = transform.position;
    }

    public void InRange()
    {
        isInRange = true;
    }

    public bool IsInRange => isInRange;

    public void OutOfRange()
    {
        isInRange = false;
    }

    public bool IsMoving
    {
        get { return lastPos != transform.position; }
    }
}
