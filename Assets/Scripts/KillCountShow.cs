using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCountShow : MonoBehaviour
{
    public TMPro.TextMeshProUGUI KillCount;
    private GameObject player;

    void Start()
    {
        player = PlayerManager.instance.player;
        KillCount.SetText("You defeated " + player.GetComponent<ShootableBox>().Score.ToString() + " Enemies!");
    }
}
