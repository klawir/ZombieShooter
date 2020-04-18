using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Creature
{
    Transform player;
    Vector3 playerLastPos;
    public NavMeshAgent meshAgent;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        if(IsPlayerMoving)
            Go();
    }
    void Go()
    {
        meshAgent.destination = player.position;
        playerLastPos = player.position;
    }
    bool IsPlayerMoving
    {
        get { return playerLastPos != player.position; }
    }
    public void Attack()
    {

    }
}
