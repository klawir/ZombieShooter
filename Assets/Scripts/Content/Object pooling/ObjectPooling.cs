using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    #region REFERENCES
    
    private List<Enemy> killedMonsters = new List<Enemy>();

    private List<Projectile> projectiles = new List<Projectile>();
    private List<PenetratingProjectile> penetratingProjectile = new List<PenetratingProjectile>();

    private List<ParticleSystem> impactEffects = new List<ParticleSystem>();
    #endregion

    #region OVERRIDES METHODS
    private void Awake()
    {
        instance = this;
    }

    #endregion

    #region METHODS
    
    public void Add(Enemy zombie)
    {
        killedMonsters.Add(zombie);
        Spawner.Instance.RespawnMonstersInTime(zombie);
    }

    public void Add(Projectile ammo)
    {
        projectiles.Add(ammo);
    }

    public void Add(PenetratingProjectile ammo)
    {
        penetratingProjectile.Add(ammo);
    }

    public void Add(ParticleSystem impactEffect)
    {
        impactEffects.Add(impactEffect);
    }

    #endregion

    #region PROPERTIES
    public ParticleSystem LoadImpactEffect
    {
        get 
        {
            ParticleSystem impactEffectToGet = impactEffects[0];
            impactEffects.RemoveAt(0);
            return impactEffectToGet;
        }
    }

    public PenetratingProjectile LoadPenetratingProjectile
    {
        get
        {
            PenetratingProjectile projectile = penetratingProjectile[0];
            penetratingProjectile.RemoveAt(0);
            return projectile;
        }
    }

    public Projectile LoadProjectile
    {
        get
        {
            Projectile projectile = projectiles[0];
            projectiles.RemoveAt(0);
            return projectile;
        }
    }
    #endregion
}
