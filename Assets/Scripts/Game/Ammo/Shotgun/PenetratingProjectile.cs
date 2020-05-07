using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for shotgun's ammo
/// </summary>
public class PenetratingProjectile : Ammo
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (!other.GetComponent<Enemy>().IsDead) {
            Destroy(gameObject);
        }
    }
}
