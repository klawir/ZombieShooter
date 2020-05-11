using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Ammo
{
    #region OVERRIDES METHODS
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Destroy(gameObject);
    }
    #endregion
}
