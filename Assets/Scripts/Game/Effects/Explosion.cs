using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public string enemyTag;
    public int damage;
    public GameObject effect;
    public GameObject burnEffect;

    private void Start()
    {
        Instantiate(effect, transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag) {
            Instantiate(burnEffect, other.transform);
            other.GetComponent<Enemy>().getDamage(damage);
        }
    }
}
