using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Global.DataLoaded == 0)
        {
            PlayerData data = SaveGame.Load();
            Global.MaxScore = data.MaxScore;
            Global.PistolKills = data.PistolKills;
            Global.KatKills = data.KatKills;
            Global.healCount = data.healCount;
            Global.AirKills = data.AirKills;
            Global.unlockedFor15 = data.unlockedFor15;
            Global.unlockedFor1 = data.unlockedFor1;
            Global.unlockedForAir = data.unlockedForAir;
            Global.unlockedFor25 = data.unlockedFor25;
            Global.unlockedFor50 = data.unlockedFor50;
            Global.unlockedFor50Gun = data.unlockedFor50Gun;
            Global.unlockedFor50Katana = data.unlockedFor50Katana;
            Global.unlockedFor20Heal = data.unlockedFor20Heal;
            Global.passedLevel5 = data.passedLevel5;
            Global.DataLoaded = 1;
        }
    }
}
