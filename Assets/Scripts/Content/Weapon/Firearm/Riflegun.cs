using UnityEngine;

public class Riflegun : Firearm
{
    #region OVERRIDES METHODS

    protected override void Start()
    {
        base.Start();
        HUD.Instance.SelectRiffleGun();
    }
    public override void Fire()
    {
        base.Fire();
        if(CanShoot) { 
            time = Time.time;
            SpawnProjectile(shootSource);
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable(); 
        HUD.Instance.SelectRiffleGun();
    }
    protected override void SpawnProjectile(Transform shootSource)
    {
        Projectile ammo = ObjectPooling.Instance.LoadProjectile;
        ammo.ReInit(shootSource, this);
    }
    #endregion
}
