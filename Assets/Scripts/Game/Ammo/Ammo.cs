using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Root class for every ammo
/// </summary>
public class Ammo : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    protected Weapon gun;

    [SerializeField]
    protected string enemyTag;

    [SerializeField]
    protected string groundTag;

    [SerializeField]
    protected GameObject implactEffect;

    [SerializeField]
    protected int speed;

    [SerializeField]
    protected Vector3 movementDirection;
    #endregion

    #region OVERRIDES METHODS
    protected virtual void Start() {
        InitMovementDirection();
        GetComponent<Rigidbody>().velocity = movementDirection * speed;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag) {
            other.GetComponent<Enemy>().getDamage(gun.Damage);
            SpawnImpactEffect(other);
        }
    }
    #endregion

    #region METHODS
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

    public void SetGun(Weapon weapon)
    {
        gun = weapon;
    }
    #endregion
}
