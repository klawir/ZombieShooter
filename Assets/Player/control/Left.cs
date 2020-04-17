using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Command
{
    public override void Execute()
    {
        player.transform.position -= Vector3.right * player.speed * Time.deltaTime;
    }
}
