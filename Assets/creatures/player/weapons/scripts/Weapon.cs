using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Transform shootSource;
    public int dmg;

    public virtual void Shoot()
    {

    }
}
