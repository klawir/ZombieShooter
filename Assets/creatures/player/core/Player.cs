using UnityEngine;

public class Player : Creature
{
    int points;

    private void Start()
    {
        UI gui = GameObject.FindObjectOfType<UI>();
        WeaponSwitcher weaponSwitcher= GameObject.FindObjectOfType<WeaponSwitcher>();
        gui.FirstInit(this);
    }
    void FixedUpdate()
    {
        if (MouseManager.IsMovement)
            Rotate();
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
