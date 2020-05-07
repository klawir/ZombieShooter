using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyBindings", menuName = "KeyBindings")]
public class KeyBindings : ScriptableObject
{
    [Header("Menu")]
    public KeyCode Pause;

    [Header("Movement")]
    public KeyCode Forward;
    public KeyCode Backward;
    public KeyCode Left;
    public KeyCode Right;

    [Header("Usable")]
    public KeyCode Attack;
    public KeyCode Grenade;

}
