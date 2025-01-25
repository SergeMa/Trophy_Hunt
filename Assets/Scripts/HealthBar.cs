using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TMPro.TextMeshProUGUI HealthLeft;
    private GameObject gameobject;
    private int health;
    void Start()
    {
        gameobject = GameObject.FindGameObjectWithTag("Player");
        health = gameobject.GetComponent<ShootableBox>().currenthealth;
        slider.maxValue = health;
        gameobject = null;
    }

    void Update()
    {
        gameobject = GameObject.FindGameObjectWithTag("Player");
        if (gameobject != null)
        {
            health = gameobject.GetComponent<ShootableBox>().currenthealth;
            slider.value = health;
            HealthLeft.SetText("Health:" + health.ToString() + "/10");
        }
        if (gameobject == null)
        {
            slider.value = 0;
            HealthLeft.SetText("Health:0/10");
        }
    }
}
