using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    static Vector3 mousePos;
    public static bool IsMovement
    {
        get { return mousePos != Input.mousePosition; }
    }
    public static void getPos()
    {
        mousePos = Input.mousePosition;
    }
}
