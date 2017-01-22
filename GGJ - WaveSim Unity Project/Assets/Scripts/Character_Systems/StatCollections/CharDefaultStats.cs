using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDefaultStats : CharStatsCollection {

    protected override void ConfigureStats()
    {
        CharStats wavePow = CreateOrGetStat(CharStatsType.WavePower);
        wavePow.StatName = "Wave Power";
        wavePow.StatValue = 100;

        CharStats mobSpd = CreateOrGetStat(CharStatsType.Mobility);
        mobSpd.StatName = "Mobility";
        mobSpd.StatValue = 15;

        CharStats handSize = CreateOrGetStat(CharStatsType.HandSize);
        handSize.StatName = "Hand Size";
        handSize.StatValue = 5;
    }
}
