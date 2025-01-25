using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider Slider;
    public TMPro.TextMeshProUGUI BHealthLeft;
    private GameObject gameobject;
    private int health;
    private int Mhealth;

    void Start()
    {
        gameobject = GameObject.FindGameObjectWithTag("Boss");
        Mhealth = gameobject.GetComponent<ShootableBox>().currenthealth;
        Slider.maxValue = Mhealth;
        gameobject = null;
    }

    void Update()
    {
        gameobject = GameObject.FindGameObjectWithTag("Boss");
        if (gameobject != null)
        {
            health = gameobject.GetComponent<ShootableBox>().currenthealth;
            Slider.value = health;
            BHealthLeft.SetText("Boss health:" + health.ToString() + "/" + Mhealth);
        }
        if (gameobject == null)
        {
            Slider.value = 0;
            BHealthLeft.SetText("Boss health:0/10");
        }
    }
}
