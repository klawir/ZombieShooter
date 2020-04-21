using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backward : Command
{
    public override void Execute()
    {
        player.transform.position -= Vector3.forward * player.speed * Time.deltaTime;
    }
}
