using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for special effects. Deals damage over time to an enemy which has been hit
/// </summary>
public class Dot : MonoBehaviour
{
    public int damage;
    public float frequencyInSecs;

    private void Start() 
    {
        Enemy enemy = GetComponentInParent<Enemy>();
        StartCoroutine(DealDamage(enemy));
    }

    private IEnumerator DealDamage(Enemy enemy)
    {
        while(!enemy.IsDead) {
            enemy.getDamage(damage);
            yield return new WaitForSeconds(frequencyInSecs);
        }
    }
}
