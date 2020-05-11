using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private NavMeshObstacle avoidance;

    [SerializeField]
    private EnemyAnimation animationManager;

    [SerializeField]
    private float modelSpeed;

    private Target target;
    #endregion

    #region OVERRIDES METHODS
    private void Start()
    {
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
    #endregion

    #region METHODS
    public Player TargetPlayer => target.Player;

    public void Disable()
    {
        agent.enabled = false;
        avoidance.enabled = true;
        target.InRange();
        transform.LookAt(target.Transform);
    }

    public void Enable()
    {
        StartCoroutine(EnableAgent());
    }

    public void Delete()
    {
        Destroy(agent);
        Destroy(avoidance.gameObject);
        Destroy(this);
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
        animationManager.PlayMove();
    }

    /// <summary>
    /// Updates model's rotate while moving
    /// </summary>
    private void Rotate()
    {
        transform.rotation = agent.transform.rotation;
    }
    #endregion
}
