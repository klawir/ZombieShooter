using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    private string enemyTag;

    [SerializeField]
    private int damage;

    [SerializeField]
    private GameObject effect;

    [SerializeField]
    private GameObject burnEffect;
    #endregion

    #region OVERRIDES METHODS
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
    #endregion
}
