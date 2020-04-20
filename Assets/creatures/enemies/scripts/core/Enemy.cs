using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Creature
{
    public NavMeshAgent agent;
    public NavMeshObstacle avoidance;
    public string playerTag;
    public int damage;
    public float speedAttack;
    public float modelSpeedNav;

    float time;
    Target target;

    void Start()
    {
        target.transform = GameObject.FindObjectOfType<Player>().transform;
        time = 0;
        CalculateMovement();
    }

    void Update()
    {
        if (!target.IsInRange)
        {
            if (target.IsMoving)
                CalculateMovement();
            MovementAndRotation();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            time = Time.time;
            target.InRange();
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
            if (CanAttack)
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
            target.OutOfRange();
            StartCoroutine("EnableAgent");
        }
    }
    private void OnDestroy()
    {
        Player _player = target.transform.GetComponentInParent<Player>();
        _player.AddPoints();
        GameObject.FindObjectOfType<UI>().SetKills(_player);
    }
    bool CanAttack
    {
        get { return Time.time > time + speedAttack; }
    }

    private IEnumerator EnableAgent()
    {
        avoidance.enabled = false;
        yield return new WaitForSeconds(Time.deltaTime);
        agent.enabled = true;
    }
    
    void CalculateMovement()
    {
        agent.destination = target.transform.position;
        target.InitLastPos();
    }
    void MovementAndRotation()
    {
        transform.position = Vector3.Lerp(transform.position, agent.transform.position, Time.deltaTime * modelSpeedNav);
        transform.rotation = agent.transform.rotation;
    }
    
    public void Attack(Collider other)
    {
        Player player = other.GetComponent<Player>();
        player.getDamage(damage);
        GameObject.FindObjectOfType<UI>().SetHP(player);
    }
}
