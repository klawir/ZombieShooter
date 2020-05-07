using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public string surfaceTag;
    public Explosion explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == surfaceTag) {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
