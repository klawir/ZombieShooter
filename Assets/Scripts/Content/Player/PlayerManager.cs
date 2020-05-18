using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    #region REFERENCES
    private Player player;

    #endregion

    #region OVERRIDES METHODS
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    #endregion

    #region PROPERTIES
    public Player Player
    {
        get { return player; }
    }
    #endregion
}
