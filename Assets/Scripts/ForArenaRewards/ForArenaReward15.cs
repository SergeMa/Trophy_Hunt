using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForArenaReward15 : MonoBehaviour
{
    public GameObject ObjFor15;
    public GameObject ObjFor15Child;
    public TMPro.TextMeshProUGUI For15;
    void Start()
    {

        if (Global.MaxScore >= 25)
        {
            ObjFor15Child.GetComponent<Renderer>().enabled = true;
            ObjFor15.GetComponent<Renderer>().enabled = true;
            For15.color = new Color32(0, 255, 0, 255);
        }
    }
}
