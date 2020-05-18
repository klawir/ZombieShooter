using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class updates UI elements
/// </summary>
public class HUD : Singleton<HUD>
{
    #region REFERENCES  
    [SerializeField]
    private Text kills;

    [SerializeField]
    private Text HP;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Image RiffleGun;

    [SerializeField]
    private Image Shotgun;

    [SerializeField]
    private Text grenades;
    #endregion

    #region OVERRIDES METHODS
    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion

    #region METHODS

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
        this.grenades.text = grenades.Amount.ToString();
    }
    public void UpdateHP(Player player)
    {
        HP.text = player.CurrentHP.ToString();
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
    public void FirstInit(Player player)
    {
        UpdateHP(player);
        UpdateKills(player);
        UpdateGranades(player.GetComponentInChildren<Grenades>());
    }
    #endregion
}
