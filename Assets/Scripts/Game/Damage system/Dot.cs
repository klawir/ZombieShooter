﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for special effects. Deals damage over time to an enemy which has been hit
/// </summary>
public class Dot : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    private int damage;

    [SerializeField]
    private float frequencyInSecs;
    #endregion]

    #region OVERRIDES METHODS
    private void Start() 
    {
        Enemy enemy = GetComponentInParent<Enemy>();
        StartCoroutine(DealDamage(enemy));
    }
    #endregion

    #region IENUMERATORS
    private IEnumerator DealDamage(Enemy enemy)
    {
        while(!enemy.IsDead) {
            enemy.getDamage(damage);
            yield return new WaitForSeconds(frequencyInSecs);
        }
    }
    #endregion
}
