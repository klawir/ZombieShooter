using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Weapon
{
    public Ammo ammo;

    public override void Shoot()
    {
        base.Shoot();
        Instantiate(ammo, shootSource.position, Quaternion.Euler(
            shootSource.transform.rotation.x, 
            shootSource.transform.rotation.y, 
            shootSource.transform.rotation.z)).gun=this;
    }
}
