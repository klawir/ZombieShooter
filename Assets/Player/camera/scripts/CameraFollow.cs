using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance;
    public float heigh;

    Vector3 targetLastPos;

    private void Update()
    {

        if (IsTargetMoved)
        {
            targetLastPos = target.position;
            Vector3 camPos = target.position;
            camPos -= Vector3.forward * distance;
            camPos.y = heigh;
            transform.position = camPos;
        }

    }
    private bool IsTargetMoved
    {
        get { return targetLastPos != target.position; }
    }
}
