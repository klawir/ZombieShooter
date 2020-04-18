using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public Pistol pistol;

    void FixedUpdate()
    {
        if (MouseManager.IsMovement)
            Rotate();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
            pistol.Shoot();
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
}
