using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    Vector3 mousePos;
    public bool IsMouseMovement
    {
        get { return mousePos != Input.mousePosition; }
    }
    public void getPos()
    {
        mousePos = Input.mousePosition;
    }
}
