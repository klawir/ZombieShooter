using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitscanner : Ammo
{
    private void Start()
    {
        Destroy(gameObject, Time.deltaTime*2);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
