using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Weapon gun;
    public string enemytag;

    protected Vector3 movementDirection;

    protected virtual void Start()
    {
        movementDirection = gun.transform.forward;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemytag)
        {
            other.GetComponent<Enemy>().getDamage(gun);
            Debug.Log(other.GetComponent<Enemy>().hp);
            Destroy(gameObject);
        }
    }
}
