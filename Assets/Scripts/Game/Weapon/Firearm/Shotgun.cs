using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Firearm
{
    #region REFERENCES  
    [SerializeField]
    private Transform additionalShootSource;
    #endregion

    #region OVERRIDES METHODS
    protected override void Start()
    {
        base.Start();
        HUD.Instance.SelectShotgun();
    }

    public override void Fire()
    {
        base.Fire();
        if (CanShoot) {
            SpawnProjectile(additionalShootSource);
            time = Time.time;
        }
    }
    #endregion
}
