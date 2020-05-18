using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindings: Singleton<KeyBindings>
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

    #region OVERRIDE METHODS
    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region PROPERTIES
    public KeyCode Pause => pause;

    public KeyCode Forward => forward;

    public KeyCode Backward => backward;

    public KeyCode Left => left;

    public KeyCode Right => right;

    public KeyCode Attack => attack;

    public KeyCode Grenade => grenade;

    public List<KeyCode> GetMovementCodes()
    {
        return new List<KeyCode>() { forward, backward, left, right };
    }

    public bool AnyMoveKeysPressed
    {
        get
        {
            return Input.GetKey(forward) ||
              Input.GetKey(backward) ||
              Input.GetKey(left) ||
              Input.GetKey(right);
        }
    }
    #endregion

}
