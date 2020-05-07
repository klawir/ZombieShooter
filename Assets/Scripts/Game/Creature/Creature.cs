using UnityEngine;


/// <summary>
/// The root class for every actor in the game
/// </summary>
public class Creature : MonoBehaviour
{
    public float speed;
    public int maxHP;
    
    [SerializeField]
    protected int currentHp;

    protected virtual void Start() => FirstInitialize();

    public virtual void getDamage(int value)
    {
        currentHp -= value;
    }

    public bool IsDead
    {
        get { return currentHp <= 0; }
    }

    private void FirstInitialize()
    {
        currentHp = maxHP;
    }
}
