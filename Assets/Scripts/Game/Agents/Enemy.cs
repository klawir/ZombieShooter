using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Creature
{
    public NavMeshAgent agent;
    public NavMeshObstacle avoidance;
    public string playerTag;
    public int damage;
    public float speedAttack;
    public Animation animation;
    public AnimationClip movement;
    public AnimationClip dead;
    public Combat combat;

    [SerializeField]
    private float modelSpeed;
    [SerializeField]
    private Target target;

    protected override void Start()
    {
        base.Start();
        Player player = GameObject.FindObjectOfType<Player>();
        target.Init(player);
        CalculateTargetPos();
    }

    private void Update()
    {
        if (!target.IsInRange) {
            if (target.IsMoving) {
                CalculateTargetPos();
            }
            Move();
            Rotate();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag) {
            PrepareToAttack();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == playerTag && !IsDead) {
            combat.Attack(target, damage);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag) {
            StartCoroutine(EnableAgent());
        }
    }
    
    public override void getDamage(int dmg)
    {
        base.getDamage(dmg);

        if (IsDead) {  
            target.Player.AddPoints();
            HUD.Instance.UpdateKills(target.Player);
            Kill();
        }
    }
    private void Kill()
    {
        Destroy(agent);
        Destroy(avoidance.gameObject);
        Destroy(GetComponent<Collider>());
        Destroy(combat);
        animation.Play(dead.name);
        Destroy(this);
    }

    /// <summary>
    /// Disables navigation, marks enemy's position as obstacle
    /// </summary>
    private void PrepareToAttack()
    {
        agent.enabled = false;
        avoidance.enabled = true;
        target.InRange();
        transform.LookAt(target.Transform);
    }

    /// <summary>
    /// Enables navigation
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnableAgent()
    {
        avoidance.enabled = false;
        yield return new WaitForSeconds(Time.deltaTime);
        target.OutOfRange();
        agent.enabled = true;
    }

    /// <summary>
    /// Calculates shortest way from enemy's position to the target's position
    /// </summary>
    private void CalculateTargetPos()
    {
        agent.destination = target.Position;
        target.InitLastPos();
    }
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, agent.transform.position, Time.deltaTime * modelSpeed);
        animation.Play(movement.name);
    }

    /// <summary>
    /// Updates model's rotate while moving
    /// </summary>
    private void Rotate()
    {
        transform.rotation = agent.transform.rotation;
    }
}
