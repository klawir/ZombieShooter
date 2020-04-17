using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : Command
{
    public override void Execute()
    {
        player.transform.position += Vector3.forward * player.speed * Time.deltaTime;
    }
}
