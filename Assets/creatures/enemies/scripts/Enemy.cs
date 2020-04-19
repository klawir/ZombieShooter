using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Creature
{
    Transform player;
    Vector3 playerLastPos;
    bool playerInRange;

    public NavMeshAgent agent;
    public NavMeshObstacle avoidance;
    public string playerTag;
    public int damage;
    public float speedAttack;
    public float modelSpeedNav;

    float time;
    
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>().transform;
        time = 0;
        CalculateMovement();
    }

    void Update()
    {
        if (!playerInRange)
        {
            if (IsPlayerMoving)
                CalculateMovement();
            MovementAndRotation();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            playerInRange = true;
            if (agent.enabled)
            {
                avoidance.enabled = true;
                agent.enabled = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == playerTag)
        {
            if (Time.time > time + speedAttack)
            {
                Attack(other);
                time = Time.time;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
            playerInRange = false;
            StartCoroutine("EnableAgent");
        }
    }
    private IEnumerator EnableAgent()
    {
        avoidance.enabled = false;
        yield return new WaitForSeconds(Time.deltaTime);
        agent.enabled = true;
    }
    void CalculateMovement()
    {
        agent.destination = player.position;
        playerLastPos = player.position;
    }
    void MovementAndRotation()
    {
        transform.position = Vector3.Lerp(transform.position, agent.transform.position, Time.deltaTime * modelSpeedNav);
        transform.rotation = agent.transform.rotation;
    }
    bool IsPlayerMoving
    {
        get { return playerLastPos != player.position; }
    }
    public void Attack(Collider other)
    {
        other.GetComponent<Player>().getDamage(damage);
    }
}
