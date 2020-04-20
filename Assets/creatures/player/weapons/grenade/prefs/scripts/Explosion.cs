using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public string enemyTag;
    public int dmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag)
            other.GetComponent<Enemy>().getDamage(dmg);
        Destroy(gameObject);
    }
}
