using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDefaultStats : CharStatsCollection {

    protected override void ConfigureStats()
    {
        var wavePow = CreateOrGetStat<CharStats>(CharStatsType.WavePower);
        wavePow.StatName = "Wave Power";
        wavePow.StatBaseValue = 100;

        var mobSpd = CreateOrGetStat<CharStats>(CharStatsType.Mobility);
        mobSpd.StatName = "Mobility";
        mobSpd.StatBaseValue = 15;

        var handSize = CreateOrGetStat<CharStats>(CharStatsType.HandSize);
        handSize.StatName = "Hand Size";
        handSize.StatBaseValue = 5;
    }
}
