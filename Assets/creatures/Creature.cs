using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public float speed;
    public int hp;

    public void getDamage(Firearm gun)
    {
        hp -= gun.dmg;
        if (IsDead)
            Destroy(gameObject);
    }
    bool IsDead
    {
        get { return hp <= 0; }
    }
}
