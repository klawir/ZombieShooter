using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : Weapon
{
    #region REFERENCES  
    [SerializeField]
    private Grenade grenade;

    [SerializeField]
    private int amount;

    [SerializeField]
    private float thrownSpeed;
    #endregion

    #region OVERRIDES METHODS
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
    #endregion

    #region METHODS
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
    #endregion

    #region PROPRETIES
    public int Amount => amount;
    #endregion
}
