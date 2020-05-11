using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : AnimationManager
{
    #region REFERENCES  
    [SerializeField]
    private AnimationClip idle;
    #endregion

    #region METHODS
    public void PlayIdle()
    {
        animation.Play(idle.name);
    }
    #endregion
}
