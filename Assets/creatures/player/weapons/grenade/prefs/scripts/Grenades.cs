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
        if (amount > 0)
        {
            if (CanShoot)
            {
                Throw();
                time = Time.time;
            }
        }
    }
    
    void Throw()
    {
        Grenade _grenade = Instantiate(grenade, shootSource.position, Quaternion.Euler(
            shootSource.transform.eulerAngles.x,
            shootSource.transform.eulerAngles.y,
            shootSource.transform.eulerAngles.z));

        Calculate(_grenade);
        amount--;
        GameObject.FindObjectOfType<UI>().SetGranades(this);
    }
    void Calculate(Grenade grenade)
    {
        grenade.GetComponent<Rigidbody>().velocity = transform.forward * transform.forward.magnitude * thrownSpeed;
    }
}
