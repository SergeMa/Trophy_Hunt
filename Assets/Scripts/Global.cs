using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public static int MaxScore;
    public static int PistolKills = 0;
    public static int KatKills = 0;
    public static int AirKills = 0;
    public static int healCount = 0;
    public static int DataLoaded = 0;
    public static bool unlockedFor1 = false;
    public static bool unlockedForAir = false;
    public static bool unlockedFor15 = false;
    public static bool unlockedFor25 = false;
    public static bool unlockedFor50 = false;
    public static bool unlockedFor50Gun = false;
    public static bool unlockedFor50Katana = false;
    public static bool unlockedFor20Heal = false;
    public static bool passedLevel5 = false;

    public void Update()
    {
        SaveGame.SavePlayer(this);
    }
}
