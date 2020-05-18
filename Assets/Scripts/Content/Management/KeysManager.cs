using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysManager : Singleton<KeysManager>
{
    #region REFERENCES
    private List<KeysInformations> keysInformations= new List<KeysInformations>();

    #endregion

    #region OVERRIDE METHODS
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateManager.instance.OnUpdate += HandleKeys;
    }

    #endregion

    #region METHODS
    private void HandleKeys()
    {
        for (int i = keysInformations.Count - 1; i >= 0; i--)
        {
            if(keysInformations[i].CheckKeys() == true) {
                keysInformations[i].HandleCurrentAction();
            }
        }
    }

    public void AddKeys(List<KeyCode> keyCodes, Action newKeyAction, KeysInformations.KeyCheckingLogicalOperationType operationType)
    {
        KeysInformations moveKeys = new KeysInformations(keyCodes, newKeyAction, operationType);
        keysInformations.Add(moveKeys);
    }
    #endregion
}
