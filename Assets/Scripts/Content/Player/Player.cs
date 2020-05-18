using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    #region REFERENCES  
    private int points;

    [SerializeField]
    private PlayerAnimations playerAnimations;

    #endregion

    #region OVERRIDES METHODS
    protected override void Start()
    {
        base.Start();
        HUD.Instance.FirstInit(this);
        AttachEvents();
    }

    private void FixedUpdate()
    {
        if (MouseManager.IsMouseMovement) {
            Rotate();
        }
    }

    public override void getDamage(int value)
    {
        base.getDamage(value);

        HUD.Instance.UpdateHP(this);
        if (IsDead) {
            Destroy(gameObject);
        }
    }
    #endregion

    #region METHODS

    private void AttachEvents()
    {
        UpdateManager.Instance.OnUpdate += UpdatePlayer;
        KeysManager.Instance.AddKeys(KeyBindings.Instance.GetMovementCodes(), Move, KeysInformations.KeyCheckingLogicalOperationType.logicalDisjunction);
    }
    private void UpdatePlayer()
    {
        if (!KeyBindings.Instance.AnyMoveKeysPressed) {
            Inertia();
        }
    }
    public void AddPoints()
    {
        points++;
    }

    public void Inertia()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime;
        playerAnimations.PlayIdle();
    }

    private void Move()
    {
        playerAnimations.PlayMove();
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
    }

    private void Rotate()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0.0f;
        if (playerPlane.Raycast(ray, out hitDist)) {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            transform.LookAt(targetPoint);
            MouseManager.getPosition();
        }
    }
    #endregion

    #region PROPERTIES
    public int Points => points;
    #endregion
}
