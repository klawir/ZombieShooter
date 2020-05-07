using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Weapon
{
    public Ammo ammo;
    public AudioSource audioSFX;
    public GameObject shootEffect;

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

    protected void SpawnProjectile(Transform shootSource)
    {
        Ammo spawnedAmmo = Instantiate(ammo, shootSource.position, Quaternion.Euler(
            shootSource.eulerAngles.x,
            shootSource.eulerAngles.y,
            shootSource.eulerAngles.z)) as Ammo;
        spawnedAmmo.gun = this;
    }

    private void SpawnShootEffect()
    {
        GameObject effect = Instantiate(shootEffect, shootSource.position, Quaternion.Euler(
            shootSource.eulerAngles.x,
            shootSource.eulerAngles.y,
            shootSource.eulerAngles.z));
        effect.transform.SetParent(transform);
    }
}
