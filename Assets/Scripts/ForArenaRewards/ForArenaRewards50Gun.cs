using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForArenaRewards50Gun : MonoBehaviour
{
    public GameObject ObjFor50G;
    public GameObject ObjFor50GChild;
    public TMPro.TextMeshProUGUI For50G;
    void Start()
    {

        if (Global.PistolKills >= 100)
        {
            ObjFor50GChild.GetComponent<Renderer>().enabled = true;
            ObjFor50G.GetComponent<Renderer>().enabled = true;
            For50G.color = new Color32(0, 255, 0, 255);
        }
    }
}
