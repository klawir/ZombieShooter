using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private Command left;
    private Command right;
    private Command forward;
    private Command backward;

    void Start()
    {
        left = new Left();
        right = new Right();
        forward = new Forward();
        backward = new Backward();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            left.Execute();
        if (Input.GetKey(KeyCode.D))
            right.Execute();
        if (Input.GetKey(KeyCode.W))
            forward.Execute();
        if (Input.GetKey(KeyCode.S))
            backward.Execute();
    }
}
