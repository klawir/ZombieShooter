using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public float speed;
    public int hp;

    public void getDamage(Weapon gun)
    {
        hp -= gun.dmg;
        if (IsDead)
            Destroy(gameObject);
    }
    public void getDamage(int dmg)
    {
        hp -= dmg;
        if (IsDead)
            Destroy(gameObject);
    }
    bool IsDead
    {
        get { return hp <= 0; }
    }
}
