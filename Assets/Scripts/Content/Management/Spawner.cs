using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    #region REFERENCES]
    private List<Enemy> spawnedMonsters;

    [SerializeField]
    private Enemy enemy;

    [SerializeField]
    private ParticleSystem impactEffect;

    [SerializeField]
    private List<Transform> enemySpawnPoints;

    [SerializeField]
    private float spawnTimeFraquency;

    [SerializeField]
    private float respawnTime;

    [SerializeField]
    private Transform waitingRoom;

    [SerializeField]
    private Transform parentForDynamicsObjects;

    [SerializeField]
    private int enemyMaxAmount = 15;

    [SerializeField]
    private int effectMaxAmount = 10;

    [SerializeField]
    private Projectile projectile;

    [SerializeField]
    private PenetratingProjectile penetratingProjectile;

    #endregion

    #region OVERRIDES METHODS

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        spawnedMonsters = new List<Enemy>();

        SpawnDeactivatedMonsters();
        SpawnDeactivatedImpactEffects();
        StartCoroutine(ActivateMonstersInTime());
        SpawnProjectile(projectile);
        SpawnProjectile(penetratingProjectile);
    }
    #endregion

    #region METHODS

    private void SpawnProjectile(Ammo projectile)
    {
        for (int a = 0; a < effectMaxAmount; a++) {
            Ammo spawnedAmmo = Instantiate(projectile, parentForDynamicsObjects);
            spawnedAmmo.Deactivate();

            if(spawnedAmmo.GetType() == (typeof (Projectile))) {
                ObjectPooling.Instance.Add(spawnedAmmo as Projectile);
            }

            if (spawnedAmmo.GetType() == (typeof(PenetratingProjectile))) {
                ObjectPooling.Instance.Add(spawnedAmmo as PenetratingProjectile);
            }
        }
    }

    public void RespawnMonstersInTime(Enemy zombie)
    {
        StartCoroutine(ReactivateMonsterInTime(zombie));
    }

    private void SpawnDeactivatedMonsters()
    {
        for (int a = 0; a < enemyMaxAmount; a++) {
            Enemy monsterToSpawn = Instantiate(enemy, waitingRoom) as Enemy;
            monsterToSpawn.FirstInitialize();
            monsterToSpawn.Deactivate();
            spawnedMonsters.Add(monsterToSpawn);
        }
    }

    private void SpawnDeactivatedImpactEffects()
    {
        for (int a = 0; a < effectMaxAmount; a++) {
            ParticleSystem spawnedImpactEffect = Instantiate(impactEffect, waitingRoom);
            spawnedImpactEffect.Pause();
            ObjectPooling.Instance.Add(spawnedImpactEffect);
        }
    }
    private IEnumerator ActivateMonstersInTime()
    {
        while (spawnedMonsters.Count > 0) {
            int size = spawnedMonsters.Count;
            EnableMonster(size - 1);
            yield return new WaitForSeconds(spawnTimeFraquency);
        }
    }

    private IEnumerator ReactivateMonsterInTime(Enemy zombie)
    {
        yield return new WaitForSeconds(respawnTime);

        zombie.transform.position = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)].position;
        zombie.Activate();
    }

    private void EnableMonster(int indexOf)
    {
        spawnedMonsters[indexOf].transform.position = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)].position;
        spawnedMonsters[indexOf].transform.SetParent(parentForDynamicsObjects);
        spawnedMonsters[indexOf].Activate();
        spawnedMonsters.RemoveAt(indexOf);
    }
    #endregion
}
