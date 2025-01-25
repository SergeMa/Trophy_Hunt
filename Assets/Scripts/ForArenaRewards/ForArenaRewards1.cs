using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForArenaRewards1 : MonoBehaviour
{
    public GameObject ObjFor1;
    public TMPro.TextMeshProUGUI For1;
    void Start()
    {

        if (Global.MaxScore >= 1)
        {
            ObjFor1.GetComponent<Renderer>().enabled = true;
            For1.color = new Color32(0, 255, 0, 255);
        }
    }
}
