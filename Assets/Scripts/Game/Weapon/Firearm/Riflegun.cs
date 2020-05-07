using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riflegun : Firearm
{
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
        }
    }
}
