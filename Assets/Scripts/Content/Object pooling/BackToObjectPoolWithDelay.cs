using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToObjectPoolWithDelay : MonoBehaviour
{
    #region REFERENCES 
    [SerializeField]
    private float delayInSecs;

    [SerializeField]
    private ParticleSystem effect;
    #endregion

    #region METHODS

    public void Go()
    {
        StartCoroutine(Run());
    }
    private IEnumerator Run()
    {
        yield return new WaitForSeconds(delayInSecs);
        ObjectPooling.Instance.Add(effect);
    }
    #endregion
}
