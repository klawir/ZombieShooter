using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : Weapon
{
    public Grenade grenade;
    public int amount;
    public float thrownSpeed;

    protected override void Start()
    {
        base.Start();
    }

    public override void Fire()
    {
        if (amount > 0) {
            if (CanShoot) {
                Throw();
                time = Time.time;
                HUD.Instance.UpdateGranades(this);
            }
        }
    }

    private void Throw()
    {
        Grenade spawnedGrenade = Instantiate(grenade, shootSource.position, Quaternion.Euler(
            shootSource.transform.eulerAngles.x,
            shootSource.transform.eulerAngles.y,
            shootSource.transform.eulerAngles.z));

        Momentum(spawnedGrenade);
        amount--;
        HUD.Instance.UpdateGranades(this);
    }

    private void Momentum(Grenade spawnedGrenade)
    {
        spawnedGrenade.GetComponent<Rigidbody>().velocity = transform.forward * transform.forward.magnitude * thrownSpeed;
    }
}
