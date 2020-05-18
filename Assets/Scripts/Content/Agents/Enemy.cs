using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Creature
{
    #region REFERENCES  
    [SerializeField]
    private EnemyAnimation animationManager;

    [SerializeField]
    private Navigation navigation;
    
    private MonoBehaviour[] components;

    #endregion

    #region OVERRIDES METHODS

    public override void getDamage(int damage)
    {
        base.getDamage(damage);

        if (IsDead) {
            navigation.TargetPlayer.AddPoints();
            HUD.Instance.UpdateKills(navigation.TargetPlayer);
            Kill();
        }
    }
    #endregion

    #region METHODS

    public override void FirstInitialize()
    {
        base.FirstInitialize();
        components = GetComponents<MonoBehaviour>();
    }

    private void Kill()
    {
        Deactivate();
        ReInitialize();
        animationManager.PlayDead();
        ObjectPooling.Instance.Add(this);
    }

    public void Deactivate()
    {
        for (int i = components.Length - 1; i >= 0; i--) {
            components[i].enabled = false;
        }
        
        GetComponent<Collider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }

    public void Activate()
    {
        for (int i = components.Length - 1; i >= 0; i--) {
            components[i].enabled = true;
        }

        GetComponent<Collider>().enabled = true;
        GetComponent<NavMeshAgent>().enabled = true;
    }
    #endregion
}
