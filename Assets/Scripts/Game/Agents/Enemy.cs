using System.Collections;
using UnityEngine;

public class Enemy : Creature
{
    #region REFERENCES  
    [SerializeField]
    private EnemyAnimation animationManager;

    [SerializeField]
    private Navigation navigation;

    [SerializeField]
    private string playerTag;

    [SerializeField]
    private Combat combat;
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
    private void Kill()
    {
        navigation.Delete();
        Destroy(GetComponent<Collider>());
        Destroy(combat);
        animationManager.PlayDead();
        Destroy(this);
    }
    #endregion
}
