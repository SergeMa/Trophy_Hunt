using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertForRewards : MonoBehaviour
{
    public GameObject Alert;

    void Update()
    {
        if (Global.MaxScore >= 15)
        {
            Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (Global.MaxScore >= 25)
        {
            Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (Global.MaxScore >= 50)
        {
            Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (Global.PistolKills >= 50)
        {
            Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (Global.KatKills >= 50)
        {
            Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (Global.healCount >= 20)
        {
            Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (Global.AirKills >= 100)
        {
            Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
