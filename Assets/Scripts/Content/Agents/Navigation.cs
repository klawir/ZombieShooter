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

    [SerializeField]
    private string targetTag;

    private Target target;
    #endregion

    #region OVERRIDES METHODS
    private void Start()
    {
        target.Init();
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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == targetTag) {
            StartCoroutine(EnableAgent());
        }
    }

    private void OnDisable()
    {
        agent.enabled = false;
        avoidance.enabled = false;
    }
    #endregion

    #region METHODS

    public void Disable()
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

    #region PROPERTIES

    public Player TargetPlayer => target.Player;
    #endregion
}
