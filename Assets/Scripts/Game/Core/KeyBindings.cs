using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindings : MonoBehaviour
{
    #region REFERENCES  
    [Header("Menu")]
    [SerializeField]
    private KeyCode pause = KeyCode.Escape;

    [Header("Movement")]
    [SerializeField]
    private KeyCode forward = KeyCode.W;

    [SerializeField]
    private KeyCode backward = KeyCode.S;

    [SerializeField]
    private KeyCode left = KeyCode.A;

    [SerializeField]
    private KeyCode right = KeyCode.D;

    [Header("Usable")]
    [SerializeField]
    private KeyCode attack = KeyCode.Mouse0;

    [SerializeField]
    private KeyCode grenade = KeyCode.V;
    #endregion

    #region METHODS
    public KeyCode Pause => pause;

    public KeyCode Forward => forward;

    public KeyCode Backward => backward;

    public KeyCode Left => left;

    public KeyCode Right => right;

    public KeyCode Attack => attack;

    public KeyCode Grenade => grenade;
    #endregion
}
