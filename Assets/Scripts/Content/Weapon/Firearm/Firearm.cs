using UnityEngine;

/// <summary>
/// The root class for every firearm
/// </summary>
public abstract class Firearm : Weapon
{
    #region REFERENCES

    [SerializeField]
    private ParticleSystem shootEffectPref;

    private ParticleSystem spawnedShootEffect;

    [SerializeField]
    private AudioSource audioSFX;
    #endregion

    #region OVERRIDES METHODS
    protected override void Start()
    {
        base.Start();
        SpawnShootEffect();
    }

    public override void Fire()
    {
        if (CanShoot) {
            spawnedShootEffect.Play();
            audioSFX.Play();
        }
    }

    protected virtual void OnEnable()
    {
        if (spawnedShootEffect) {
            spawnedShootEffect.Play();
            spawnedShootEffect.Pause();
        }
    }
    #endregion

    #region METHODS
    protected abstract void SpawnProjectile(Transform shootSource);

    private void SpawnShootEffect()
    {
        spawnedShootEffect = Instantiate(shootEffectPref, shootSource.position, Quaternion.Euler(
            shootSource.eulerAngles.x,
            shootSource.eulerAngles.y,
            shootSource.eulerAngles.z));
        spawnedShootEffect.transform.SetParent(transform);
        spawnedShootEffect.Pause();
    }
    
    #endregion
}
