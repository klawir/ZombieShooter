using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    [SerializeField]
    private int points;

    public KeyBindings keyBindings;
    public Animation animation;
    public AnimationClip move;
    public AnimationClip idle;
    public Text HP;

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
            animation.Play(idle.name);
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
    private void Inertia()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime;
    }

    public override void getDamage(int value)
    {
        base.getDamage(value);
        if (IsDead) {
            Destroy(gameObject);
        }
        UpgradeGUIHP();
    }

    private void UpgradeGUIHP()
    {
        HP.text = currentHp.ToString();
    }

    private void Move()
    {
        animation.Play(move.name);
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

    public int Points => points;

    public void AddPoints()
    {
        points++;
    }
}
