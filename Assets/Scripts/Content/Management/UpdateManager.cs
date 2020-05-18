using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : Singleton<UpdateManager>
{
    #region REFERENCES
    public event Action OnUpdate = delegate { };

    #endregion

    #region OVERRIDE METHODS
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        OnUpdate();
    }

    #endregion
}
