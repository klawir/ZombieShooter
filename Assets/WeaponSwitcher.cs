using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public Firearm pistol;
    public Firearm shotgun;
    public Weapon currentGun;
    public Player player;
    public Grenades grenades;
    public Transform gunSlot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DeleteOther();
            Switch(pistol);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DeleteOther();
            Switch(shotgun);
        }
        if (Input.GetMouseButton(0))
            currentGun.Fire();
        if (Input.GetKeyDown(KeyCode.V))
            grenades.Fire();
    }
    private void Switch(Firearm gun)
    {
        Firearm spawnedGun = Instantiate(gun, gunSlot);
        currentGun = spawnedGun;
    }
    private void DeleteOther()
    {
        Destroy(gunSlot.GetComponentInChildren<Firearm>().gameObject);
    }
}
