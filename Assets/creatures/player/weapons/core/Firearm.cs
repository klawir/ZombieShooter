using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Weapon
{
    public Ammo ammo;

    public override void Fire()
    {
        if (CanShoot)
        {
            SpawnProjectile();
            time = Time.time;
        }
    }
    void SpawnProjectile()
    {
        Instantiate(ammo, shootSource.position, Quaternion.Euler(
            shootSource.transform.eulerAngles.x,
            shootSource.transform.eulerAngles.y + 180f,
            shootSource.transform.eulerAngles.z)).gun = this;
    }
}
