using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    #region REFERENCES  
    protected static T instance;
    #endregion

    #region PROPERTIES
    public static T Instance
    {
        get { return instance; }
    }
    #endregion
}