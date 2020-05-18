using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    #region REFERENCES  
    [SerializeField]
    private Riflegun rifleGun;

    [SerializeField]
    private Shotgun shotgun;

    [SerializeField]
    private KeyBindings keyBindings;

    [SerializeField]
    private Firearm currentGun;

    [SerializeField]
    private Grenades grenades;

    [SerializeField]
    private Transform gunSlot;

    private Riflegun spawnedRifleGun;
    private Shotgun spawnedShotgun;
    #endregion

    #region OVERRIDES METHODS
    private void Start()
    {
        if (!IsGunExist) {
            IniDefault();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Switch(spawnedRifleGun);
            Deactivate(spawnedShotgun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Switch(spawnedShotgun);
            Deactivate(spawnedRifleGun);
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
        Activate(gun);
        InitCurrent(gun);
    }

    private void Deactivate(Firearm gun)
    {
        gun.gameObject.SetActive(false);
    }

    private void Activate(Firearm gun)
    {
        gun.gameObject.SetActive(true);
    }

    private void InitCurrent(Firearm spawnedGun)
    {
        currentGun = spawnedGun;
    }

    private void IniDefault()
    {
        spawnedRifleGun = Instantiate(rifleGun, gunSlot);
        spawnedShotgun = Instantiate(shotgun, gunSlot);

        Deactivate(spawnedShotgun);
        InitCurrent(spawnedRifleGun);
    }
    #endregion
}
