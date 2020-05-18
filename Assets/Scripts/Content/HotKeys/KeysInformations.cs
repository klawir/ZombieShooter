using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysInformations
{
    #region REFERENCES
    private List<KeyCode> keyCodes= new List<KeyCode>();

    private KeyCheckingLogicalOperationType operationType;

    public enum KeyCheckingLogicalOperationType { logicalDisjunction, logicalConjunction }

    private event Action onKeysAction = delegate { };
    #endregion

    #region METHODS
    public KeysInformations(List<KeyCode> keys, Action newKeyAction, KeyCheckingLogicalOperationType operationType)
    {
        keyCodes = keys;
        onKeysAction = newKeyAction;
        this.operationType = operationType;
    }

    public void HandleCurrentAction()
    {
        onKeysAction();
    }

    public bool CheckKeys()
    {
        switch (operationType)
        {
            case KeyCheckingLogicalOperationType.logicalConjunction:
                return CheckKeysLogicalConjunction();
            case KeyCheckingLogicalOperationType.logicalDisjunction:
            default:
                return CheckKeysLogicalDisjunction();
        }
    }

    private bool CheckKeysLogicalDisjunction()
    {
        foreach (KeyCode key in keyCodes) {
            if (Input.GetKey(key)) {
                return true;
            }
        }
        return false;
    }

    private bool CheckKeysLogicalConjunction()
    {
        bool isPressed = false;

        foreach (KeyCode key in keyCodes) {
            if (Input.GetKey(key)) {
                isPressed = true;
            } else {
                return false;
            }
        }
        return isPressed;
    }

    #endregion
    
}
