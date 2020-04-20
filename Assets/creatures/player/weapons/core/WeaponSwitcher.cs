using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public Firearm pistol;
    public Firearm shotgun;
    public Weapon currentGun;
    public Grenades grenades;
    public Transform gunSlot;

    public Player player;
    public UI gui;

    private void Start()
    {
        InitDefault();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DeleteOther();
            Switch(pistol);
            gui.SwitchToPistol();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DeleteOther();
            Switch(shotgun);
            gui.SwitchToShotgun();
        }
        if (Input.GetMouseButton(0))
            currentGun.Fire();
        if (Input.GetKeyDown(KeyCode.V))
            grenades.Fire();
    }
    private void Switch(Firearm gun)
    {
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
    private void InitDefault()
    {
        Firearm detected = player.GetComponentInChildren<Shotgun>();
        if (detected == null)
            Switch(pistol);
        else
            InitCurrent(detected);
    }
}
