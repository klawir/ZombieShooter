using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Weapon
{
    #region REFERENCES  
    [SerializeField]
    public Ammo ammo;

    [SerializeField]
    public AudioSource audioSFX;

    [SerializeField]
    public GameObject shootEffect;
    #endregion

    #region OVERRIDES METHODS
    protected override void Start()
    {
        base.Start();
    }

    public override void Fire()
    {
        if (CanShoot) {
            SpawnProjectile(shootSource);
            SpawnShootEffect();
            audioSFX.Play();
        }
    }
    #endregion

    #region METHODS
    protected void SpawnProjectile(Transform shootSource)
    {
        Ammo spawnedAmmo = Instantiate(ammo, shootSource.position, Quaternion.Euler(
            shootSource.eulerAngles.x,
            shootSource.eulerAngles.y,
            shootSource.eulerAngles.z)) as Ammo;
        spawnedAmmo.SetGun(this);
    }

    private void SpawnShootEffect()
    {
        GameObject effect = Instantiate(shootEffect, shootSource.position, Quaternion.Euler(
            shootSource.eulerAngles.x,
            shootSource.eulerAngles.y,
            shootSource.eulerAngles.z));
        effect.transform.SetParent(transform);
    }
    #endregion
}
