using UnityEngine;

/// <summary>
/// The root class for every actor in the game
/// </summary>
public class Creature : MonoBehaviour
{
    #region REFERENCES 
    [SerializeField]
    protected float speed;

    [SerializeField]
    private int HP;

    [SerializeField]
    protected int currentHp;
    #endregion

    #region OVERRIDES METHODS
    protected virtual void Start()
    {
        FirstInitialize();
    }

    public virtual void getDamage(int value)
    {
        currentHp -= value;
    }
    #endregion

    #region METHODS
    public virtual void FirstInitialize()
    {
        currentHp = HP;
    }

    protected void ReInitialize()
    {
        currentHp = HP;
    }
    #endregion

    #region PROPERTIES
    public bool IsDead
    {
        get { return currentHp <= 0; }
    }

    public int CurrentHP => currentHp;
    #endregion]
}
