using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    public Animation animation;
    public AnimationClip attack;

    //attack animation hit moment in percent
    public float hitMomentAnim;

    //blocks next deal damage after first call DealDamage(Target target, int damage);
    private bool dealtDamage;

    private float hitMomment;
    private float onePercentOfAttackAnim;

    private void Start()
    {
        onePercentOfAttackAnim = (animation[attack.name].length / 100);
        hitMomment = onePercentOfAttackAnim * hitMomentAnim;
    }

    private bool IsHitMomment
    {
        get { return animation[attack.name].time > hitMomment; }
    }

    private bool IsBeginningOfAnim
    {
        get { return animation[attack.name].time < onePercentOfAttackAnim; }
    }

    private void DealDamage(Target target, int damage)
    {
        target.Player.getDamage(damage);
        dealtDamage = true;
    }

    public void Attack(Target target, int damage)
    {
        animation.Play(attack.name);
        if (IsHitMomment && !dealtDamage) {
            DealDamage(target, damage);
        }
        if (IsBeginningOfAnim) { 
            dealtDamage = false;
        }
    }
}
