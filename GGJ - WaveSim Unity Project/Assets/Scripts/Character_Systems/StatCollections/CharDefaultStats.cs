using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDefaultStats : CharStatsCollection {

    protected override void ConfigureStats()
    {
        var handSize = CreateOrGetStat<CharAttributes>(CharStatsType.HandSize);
        handSize.StatName = "Hand Size";
        handSize.StatBaseValue = 10;

        var wavePow = CreateOrGetStat<CharAttributes>(CharStatsType.WavePower);
        wavePow.StatName = "Wave Power";
        wavePow.StatBaseValue = 100;
        wavePow.AddLinker(new CharStatLinkerBasic(CreateOrGetStat<CharAttributes>(CharStatsType.HandSize), 12f));
        wavePow.UpdateLinkers();

        var mobSpd = CreateOrGetStat<CharAttributes>(CharStatsType.Mobility);
        mobSpd.StatName = "Mobility";
        mobSpd.StatBaseValue = 15;
        mobSpd.AddLinker(new CharStatLinkerBasic(CreateOrGetStat<CharAttributes>(CharStatsType.HandSize), 10f));
        mobSpd.UpdateLinkers();
    }
}
