﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    private EnemyAnimation animations;

    [SerializeField]
    private Navigation navigation;

    [SerializeField]
    private string playerTag;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float speedAttack = 1;

    //blocks next deal damage after first call DealDamage(Target target, int damage);
    private bool dealtDamage;

    private float time;

    #endregion

    #region OVERRIDES METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag) {
            PrepareToAttack();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == playerTag) {
            if (ChargeTimeOfAttack) { 
                Attack(navigation.TargetPlayer, damage);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag) {
            navigation.Enable();
        }
    }
    #endregion

    #region METHODS
    public void Attack(Player player, int damage)
    {
        animations.PlayAttack();
        if (animations.IsHitMomment && !dealtDamage)
        {
            DealDamage(player, damage);
        }
        if (animations.IsBeginningOfAttackAnim)
        {
            dealtDamage = false;
            time = Time.time;
        }
    }

    /// <summary>
    /// Disables navigation, marks enemy's position as obstacle
    /// </summary>
    private void PrepareToAttack()
    {
        navigation.Disable();
    }

    private void DealDamage(Player player, int damage)
    {
        player.getDamage(damage);
        dealtDamage = true;
    }
    #endregion

    #region PROPERTIES

    private bool ChargeTimeOfAttack
    { 
        get { return Time.time > time + speedAttack; }
    }

    #endregion
}
