using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    public string objName;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == objName)
            Destroy(other.gameObject);
    }
}
