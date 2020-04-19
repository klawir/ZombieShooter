using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Transform shootSource;
    public int dmg;
    public float shotFraquency;

    protected float time;

    protected virtual void Start()
    {
        time = 0;
    }
    protected bool CanShoot
    {
        get { return Time.time > time + shotFraquency; }
    }
    public abstract void Fire();
    
}
