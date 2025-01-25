using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int MaxScore;
    public int PistolKills;
    public int KatKills;
    public int AirKills;
    public int healCount;
    public bool unlockedFor15;
    public bool unlockedForAir;
    public bool unlockedFor25;
    public bool unlockedFor50;
    public bool unlockedFor50Gun;
    public bool unlockedFor50Katana;
    public bool unlockedFor20Heal;
    public bool unlockedFor1;
    public bool passedLevel5;

    public PlayerData(Global player)
    {
        MaxScore = Global.MaxScore;
        PistolKills = Global.PistolKills;
        KatKills = Global.KatKills;
        healCount = Global.healCount;
        AirKills = Global.AirKills;
        unlockedFor15 = Global.unlockedFor15;
        unlockedForAir = Global.unlockedForAir;
        unlockedFor25 = Global.unlockedFor25;
        unlockedFor50 = Global.unlockedFor50;
        unlockedFor50Gun = Global.unlockedFor50Gun;
        unlockedFor50Katana = Global.unlockedFor50Katana;
        unlockedFor20Heal = Global.unlockedFor20Heal;
        unlockedFor1 = Global.unlockedFor1;
        passedLevel5 = Global.passedLevel5;
    }
}
