using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    #region REFERENCES  
    [SerializeField]
    private int points;

    [SerializeField]
    private KeyBindings keyBindings;

    [SerializeField]
    private PlayerAnimations playerAnimations;

    [SerializeField]
    private Text HP;
    #endregion

    #region OVERRIDES METHODS
    protected override void Start()
    {
        base.Start();
        UpgradeGUIHP();
    }

    private void FixedUpdate()
    {
        if (MouseManager.IsMouseMovement) {
            Rotate();
        }
        if (!Input.anyKey) {
            Inertia();
            playerAnimations.PlayIdle();
        }
    }
    private void Update()
    {
        if (Input.GetKey(keyBindings.Forward) ||
            Input.GetKey(keyBindings.Backward) ||
            Input.GetKey(keyBindings.Left) ||
            Input.GetKey(keyBindings.Right)) {
            Move();
        }
    }

    public override void getDamage(int value)
    {
        base.getDamage(value);
        if (IsDead)
        {
            Destroy(gameObject);
        }
        UpgradeGUIHP();
    }
    #endregion

    #region METHODS

    public void AddPoints()
    {
        points++;
    }

    private void Inertia()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime;
    }

    private void UpgradeGUIHP()
    {
        HP.text = currentHp.ToString();
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
