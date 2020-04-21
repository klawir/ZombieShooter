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
    public EnemyUI ui;

    float attackCoolDown;
    Target target;

    void Start()
    {
        Player player= GameObject.FindObjectOfType<Player>();
        target.Init(player);
        attackCoolDown = 0;
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
            AttackCoolDown();
            target.InRange();
            agent.enabled = false;
            avoidance.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == playerTag)
        {
            if (CanAttack)
            {
                Attack(target);
                AttackCoolDown();
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
        target.player.AddPoints();
        GameObject.FindObjectOfType<UI>().SetKills(target.player);
    }
    public override void getDamage(int dmg)
    {
        base.getDamage(dmg);
        ui.RenderDamage(dmg);
        if (IsDead)
            Destroy(gameObject);
    }
    bool CanAttack
    {
        get { return Time.time > attackCoolDown + speedAttack; }
    }
    void AttackCoolDown()
    {
        attackCoolDown = Time.time;
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
    
    public void Attack(Target target)
    {
        target.player.getDamage(damage);
    }
}
