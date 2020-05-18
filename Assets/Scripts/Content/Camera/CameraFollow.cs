using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 targetLastPos;
    #endregion

    #region OVERRIDES METHODS
    private void Update()
    {
        if (IsTargetMoved) {
            Follow();
        }
    }
    #endregion

    #region METHODS
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
    #endregion
}
