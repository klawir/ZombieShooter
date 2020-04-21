using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    public float durationTime;
    
    void Start()
    {
        Destroy(gameObject, durationTime);
    }
}
