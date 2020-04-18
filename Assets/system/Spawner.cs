using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemy;
    public Transform spawnPoint;
    public float spawnTimeFraquency;

    public void Spawn()
    {
        Instantiate(enemy, spawnPoint.position, enemy.transform.rotation);
    }
    private void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnTimeFraquency);
    }

}
