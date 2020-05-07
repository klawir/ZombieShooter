using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The root class for every weapon
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    public Transform shootSource;
    public int damage;
    public float speedAttack;

    protected float time;

    protected virtual void Start()
    {
        time = 0;
    }

    protected bool CanShoot
    {
        get { return Time.time > time + speedAttack; }
    }
    public abstract void Fire();
}
