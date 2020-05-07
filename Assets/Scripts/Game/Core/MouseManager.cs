using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private static Vector3 mousePos;

    public static bool IsMouseMovement
    {
        get { return mousePos != Input.mousePosition; }
    }

    public static void getPosition()
    {
        mousePos = Input.mousePosition;
    }
}
