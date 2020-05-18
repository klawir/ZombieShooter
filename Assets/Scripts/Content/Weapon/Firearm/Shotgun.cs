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
            SpawnProjectile(shootSource);
            SpawnProjectile(additionalShootSource);
            time = Time.time;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        HUD.Instance.SelectShotgun();
    }

    protected override void SpawnProjectile(Transform shootSource)
    {
        PenetratingProjectile ammo = ObjectPooling.Instance.LoadPenetratingProjectile;
        ammo.ReInit(shootSource, this);
    }
    #endregion
}
