using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : AnimationManager
{
    #region REFERENCES
    [SerializeField]
    private AnimationClip dead;

    [SerializeField]
    private AnimationClip attack;

    //attack animation hit moment in percent
    [SerializeField]
    private float hitMomentAnim;

    private float onePercentOfAttackAnim;
    #endregion

    #region OVERRIDES METHODS
    private void Start()
    {
        onePercentOfAttackAnim = (animation[attack.name].length / 100);
    }
    #endregion

    #region METHODS

    public bool IsHitMomment
    {
        get { return animation[attack.name].time > onePercentOfAttackAnim * hitMomentAnim; }
    }

    public bool IsEndOfAttackAnim
    {
        get { return animation[attack.name].time >= animation[attack.name].length - onePercentOfAttackAnim; }
    }

    public void PlayDead()
    {
        animation.Play(dead.name);
    }

    public void PlayAttack()
    {
        animation.Play(attack.name);
    }
    #endregion
}
