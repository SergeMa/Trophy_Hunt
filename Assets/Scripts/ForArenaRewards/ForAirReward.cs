using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAirReward : MonoBehaviour
{
    public GameObject ObjFor100Air;
    public TMPro.TextMeshProUGUI For100Air;
    void Update()
    {

        if (Global.AirKills >= 100)
        {
            if (ObjFor100Air.activeSelf == false)
            {
                ObjFor100Air.SetActive(true);
                For100Air.color = new Color32(0, 255, 0, 255);
            }
        }
    }
}
