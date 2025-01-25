using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForArenaReward50 : MonoBehaviour
{
    public GameObject ObjFor50;
    public TMPro.TextMeshProUGUI For50;
    void Start()
    {

        if (Global.MaxScore >= 100)
        {
            ObjFor50.GetComponent<Renderer>().enabled = true;
            For50.color = new Color32(0, 255, 0, 255);
        }
    }

}
