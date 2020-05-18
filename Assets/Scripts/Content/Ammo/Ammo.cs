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
    protected int speed;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private TrailRenderer trailEffect;

    private Vector3 movementDirection;

    #endregion

    #region OVERRIDES METHODS

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag) {
            other.GetComponent<Enemy>().getDamage(gun.Damage);
            SpawnImpactEffect(other);
        }
    }

    #endregion

    #region METHODS
    protected void SpawnImpactEffect(Collider target)
    {
        ParticleSystem impactEffect = ObjectPooling.Instance.LoadImpactEffect;
        impactEffect.Play();
        impactEffect.transform.position = target.transform.position;
        impactEffect.transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            transform.eulerAngles.z);
        impactEffect.GetComponent<BackToObjectPoolWithDelay>().Go();
    }
    private void InitMovementDirection()
    {
        movementDirection = gun.transform.forward;
        rigidbody.velocity = movementDirection * speed;
    }
    private void InitGun(Weapon weapon)
    {
        gun = weapon;
    }
    public void ReInit(Transform shootSource, Weapon weapon)
    {
        InitGun(weapon);
        InitMovementDirection();
        transform.position = shootSource.position;
        transform.rotation = Quaternion.Euler(
            shootSource.eulerAngles.x,
            shootSource.eulerAngles.y,
            shootSource.eulerAngles.z);
        Activate();
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Activate()
    {
        gameObject.SetActive(true);
    }
    #endregion
}
