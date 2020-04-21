using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Text dmg;
    public Transform startPos;
    public Canvas ui;

    private void Start()
    {
        ui.worldCamera = GameObject.FindObjectOfType<Camera>();
    }
    public void RenderDamage(int value)
    {
        Text textDmg = Instantiate(dmg, ui.transform, false) as Text;
        textDmg.text = value.ToString();
        textDmg.transform.position = startPos.position;
    }
}
