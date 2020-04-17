using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected Player player;

    public Command()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    public abstract void Execute();
}
