using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Ammo
{
    #region OVERRIDES METHODS

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        Deactivate();
        ObjectPooling.Instance.Add(this);
    }

    private void OnBecameInvisible()
    {
        Deactivate();
        ObjectPooling.Instance.Add(this);
    }
    #endregion
}
