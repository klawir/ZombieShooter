using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The root class for every weapon
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    #region REFERENCES 
    [SerializeField]
    protected Transform shootSource;

    [SerializeField]
    protected int damage;

    [SerializeField]
    protected float speedAttack;

    protected float time;
    #endregion

    #region OVERRIDES METHODS
    protected virtual void Start()
    {
        time = 0;
    }

    public abstract void Fire();

    #endregion

    #region METHODS
    protected bool CanShoot
    {
        get { return Time.time > time + speedAttack; }
    }
    #endregion

    #region PROPERTIES
    public int Damage => damage;
    #endregion
}
