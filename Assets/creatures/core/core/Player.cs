using UnityEngine;

public class Player : Creature
{
    int points;
    public UI ui;

    private void Start()
    {
        WeaponSwitcher weaponSwitcher= GameObject.FindObjectOfType<WeaponSwitcher>();
        ui.FirstInit(this);
    }
    void FixedUpdate()
    {
        if (MouseManager.IsMovement)
            Rotate();
    }
    public override void getDamage(int dmg)
    {
        base.getDamage(dmg);
        if (IsDead)
            Destroy(gameObject);
        ui.SetHP(this);
    }
    void Rotate()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            transform.LookAt(targetPoint);
            MouseManager.getPos();
        }
    }
    public int Points
    {
        get { return points; }
    }
    public void AddPoints()
    {
        points++;
    }
}
