using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForArenaRewards50K : MonoBehaviour
{
    public GameObject ObjFor50K;
    public GameObject ObjFor50KChild;
    public TMPro.TextMeshProUGUI For50K;
    void Start()
    {

        if (Global.KatKills >= 100)
        {
            ObjFor50KChild.GetComponent<Renderer>().enabled = true;
            ObjFor50K.GetComponent<Renderer>().enabled = true;
            For50K.color = new Color32(0, 255, 0, 255);
        }
    }
}
