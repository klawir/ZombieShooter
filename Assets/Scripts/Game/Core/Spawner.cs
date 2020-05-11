using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    private Enemy enemy;

    [SerializeField]
    private List<Transform> spawnPoints;

    [SerializeField]
    private float spawnTimeFraquency;

    [SerializeField]
    private Transform parent;
    #endregion

    #region OVERRIDES METHODS
    private void Start() => InvokeRepeating("Spawn", 0f, spawnTimeFraquency);
    #endregion]

    #region METHODS
    public void Spawn()
    {
        Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Count)].position, enemy.transform.rotation).transform.SetParent(parent);
    }
    #endregion
}
