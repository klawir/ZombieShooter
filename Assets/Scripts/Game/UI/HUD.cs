using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class updates UI elements
/// </summary>
public class HUD : Singleton<HUD>
{
    public Text kills;
    public Text HP;
    public Canvas canvas;
    public Image RiffleGun;
    public Image Shotgun;
    public Text grenades;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() => FirstInit();
    
    /// <summary>
    /// Updates player's score
    /// </summary>
    /// <param name="player"></param>
    public void UpdateKills(Player player)
    {
        kills.text = player.Points.ToString();
    }

    public void UpdateGranades(Grenades grenades)
    {
        this.grenades.text = grenades.amount.ToString();
    }

    public void SelectRiffleGun()
    {
        RiffleGun.color = Color.green;
        Shotgun.color = Color.white;
    }

    public void SelectShotgun()
    {
        Shotgun.color = Color.green;
        RiffleGun.color = Color.white;
    }

    /// <summary>
    /// Upgrades all HUD elements
    /// </summary>
    /// <param name="player"></param>
    private void FirstInit()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        kills.text = player.Points.ToString();
        grenades.text = player.GetComponentInChildren<Grenades>().amount.ToString();
    }
}
