using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public float speed;
    public int hp;

    public virtual void getDamage(int dmg)
    {
        hp -= dmg;
    }
    protected bool IsDead
    {
        get { return hp <= 0; }
    }
}
