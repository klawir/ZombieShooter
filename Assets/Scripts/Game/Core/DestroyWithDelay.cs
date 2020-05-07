using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
    public float delaynInSecs;

    private void Start()
    {
        Destroy(gameObject, delaynInSecs);
    }
}
