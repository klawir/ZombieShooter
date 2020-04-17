using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    MouseManager mouseManager;
    private void Start()
    {
        mouseManager = GameObject.FindObjectOfType<MouseManager>();
    }
    void FixedUpdate()
    {
        if (mouseManager.IsMouseMovement)
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
            mouseManager.getPos();
        }
    }
}
