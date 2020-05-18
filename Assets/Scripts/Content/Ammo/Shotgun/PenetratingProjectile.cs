using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for shotgun's ammo
/// </summary>
public class PenetratingProjectile : Ammo
{

    #region OVERRIDES METHODS
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (!other.GetComponent<Enemy>().IsDead) {
            ObjectPooling.Instance.Add(this);
            Deactivate();
        }
    }

    private void OnBecameInvisible()
    {
        Deactivate();
        ObjectPooling.Instance.Add(this);
    }
    #endregion
}
