using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
    #region REFERENCES 
    [SerializeReference]
    private float delaynInSecs;
    #endregion

    #region OVERRIDES METHODS
    private void Start()
    {
        Destroy(gameObject, delaynInSecs);
    }
    #endregion
}
