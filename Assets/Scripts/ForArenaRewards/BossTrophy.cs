using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrophy : MonoBehaviour
{
    public GameObject ObjForPass;
    public TMPro.TextMeshProUGUI ForPass;
    // Update is called once per frame
    void Update()
    {
        if(Global.passedLevel5 == true && ObjForPass.activeSelf == false)
        {
            ObjForPass.SetActive(true);
            ForPass.color = new Color32(0, 255, 0, 255);
        }
    }
}
