using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForArenaRewards : MonoBehaviour
{
    public GameObject ObjFor25;
    public TMPro.TextMeshProUGUI For25;
    void Start()
    {

        if (Global.MaxScore >= 50)
        {
            ObjFor25.GetComponent<Renderer>().enabled = true;
            For25.color = new Color32(0, 255, 0, 255);
        }
    }
}
