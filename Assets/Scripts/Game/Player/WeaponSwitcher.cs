using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    public Firearm rifleGun;
    public Firearm shotgun;

    public KeyBindings keyBindings;
    public Firearm currentGun;
    public Grenades grenades;
    public Transform gunSlot;
    public Player player;

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
}
