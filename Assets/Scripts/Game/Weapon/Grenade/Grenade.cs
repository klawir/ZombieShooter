using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    private string surfaceTag;

    [SerializeField]
    private Explosion explosion;
    #endregion

    #region OVERRIDES METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == surfaceTag) {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
    #endregion
}
