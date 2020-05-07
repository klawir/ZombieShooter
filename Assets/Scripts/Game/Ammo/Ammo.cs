using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Root class for every ammo
/// </summary>
public class Ammo : MonoBehaviour
{
    public Weapon gun;
    public string enemyTag;
    public string groundTag;
    public GameObject implactEffect;
    public int speed;
    protected Vector3 movementDirection;

    protected virtual void Start() {
        InitMovementDirection();
        GetComponent<Rigidbody>().velocity = movementDirection * speed;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag) {
            other.GetComponent<Enemy>().getDamage(gun.damage);
            SpawnImpactEffect(other);
        }
    }

    private void SpawnImpactEffect(Collider target)
    {
        Instantiate(implactEffect, target.transform.position, Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            transform.eulerAngles.z));
    }

    private void InitMovementDirection()
    {
        movementDirection = gun.transform.forward;
    }
}
