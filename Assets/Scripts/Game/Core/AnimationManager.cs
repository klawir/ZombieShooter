using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    protected Animation animation;

    [SerializeField]
    protected AnimationClip move;

    #endregion

    #region METHODS
    public void PlayMove()
    {
        animation.Play(move.name);
    }
    #endregion
}
