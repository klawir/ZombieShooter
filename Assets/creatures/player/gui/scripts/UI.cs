using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text kills;
    public Text hp;
    public Text grenades;

    public Image pistol;
    public Image shotgun;

    public void SwitchToPistol()
    {
        pistol.color = Color.green;
        shotgun.color = Color.white;
    }
    public void SwitchToShotgun()
    {
        shotgun.color = Color.green;
        pistol.color = Color.white;
    }
    public void SetKills(Player player)
    {
        kills.text = player.Points.ToString();
    }
    public void SetHP(Player player)
    {
        hp.text = player.hp.ToString();
    }
    public void SetGranades(Grenades grenades)
    {
        this.grenades.text = grenades.amount.ToString();
    }
    public void FirstInit(Player player)
    {
        DetectWeapon(player);
        kills.text = player.Points.ToString();
        hp.text = player.hp.ToString();
        grenades.text = player.GetComponentInChildren<Grenades>().amount.ToString();
    }
    void DetectWeapon(Player player)
    {
        Weapon detected = player.GetComponentInChildren<Shotgun>();
        if (detected != null)
            SwitchToShotgun();
        else
            SwitchToPistol();
    }
}
