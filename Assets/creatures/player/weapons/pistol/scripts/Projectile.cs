using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Ammo
{
    public int speed;

    protected override void Start()
    {
        base.Start();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    void Movement()
    {
        transform.position += movementDirection * speed * Time.deltaTime;
    }
}
