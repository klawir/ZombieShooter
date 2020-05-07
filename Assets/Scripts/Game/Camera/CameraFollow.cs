using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 targetLastPos;

    private void Update()
    {
        if (IsTargetMoved) {
            Follow();
        }
    }

    private void Follow()
    {
        targetLastPos = target.position;
        Vector3 camPos = target.position;
        camPos.y = transform.position.y;
        transform.position = camPos;
    }

    private bool IsTargetMoved
    {
        get { return targetLastPos != target.position; }
    }
}
