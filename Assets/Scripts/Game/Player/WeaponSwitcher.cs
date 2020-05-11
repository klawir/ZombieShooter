using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    private Firearm rifleGun;

    [SerializeField]
    private Firearm shotgun;

    [SerializeField]
    private KeyBindings keyBindings;

    [SerializeField]
    private Firearm currentGun;

    [SerializeField]
    private Grenades grenades;

    [SerializeField]
    private Transform gunSlot;

    [SerializeField]
    private Player player;
    #endregion

    #region OVERRIDES METHODS
    private void Start()
    {
        if(!IsGunExist) {
            IniDefault();
        }
        else {
            currentGun = GetComponentInChildren<Firearm>();
            InitCurrent(currentGun);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Switch(rifleGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Switch(shotgun);
        }
        if(Input.GetKey(keyBindings.Attack)) {
            currentGun.Fire();
        }
        if (Input.GetKeyDown(keyBindings.Grenade)) { 
            grenades.Fire();
        }
    }
    #endregion

    #region METHODS
    private bool IsGunExist
    {
        get { return gunSlot.childCount > 0; }
    }

    private void Switch(Firearm gun)
    {
        if (IsGunExist) {
            DeleteOther();
        }
        Firearm spawnedGun = Instantiate(gun, gunSlot);
        InitCurrent(spawnedGun);
    }

    private void DeleteOther()
    {
        Destroy(gunSlot.GetComponentInChildren<Firearm>().gameObject);
    }

    private void InitCurrent(Firearm spawnedGun)
    {
        currentGun = spawnedGun;
    }

    private void IniDefault()
    {
        Switch(rifleGun);
    }
    #endregion
}
