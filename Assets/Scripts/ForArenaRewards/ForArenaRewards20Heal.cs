using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForArenaRewards20Heal : MonoBehaviour
{
    public GameObject ObjFor20Heal;
    public TMPro.TextMeshProUGUI For50K;
    void Start()
    {

        if (Global.healCount >= 20)
        {
            ObjFor20Heal.SetActive(true);
            For50K.color = new Color32(0, 255, 0, 255);
        }
    }
}
