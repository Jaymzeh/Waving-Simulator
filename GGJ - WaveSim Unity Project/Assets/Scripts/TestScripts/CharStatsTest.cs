using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharStatsTest : MonoBehaviour {
    private CharStatsCollection stats;

	void Start() {
        stats = new CharDefaultStats();

        DisplayStatValues();

        var wavePower = stats.GetStat<CharStatModifiable>(CharStatsType.WavePower);
        wavePower.AddModifier(new CharStatModifier(CharStatsType.WavePower, CharStatModifier.Types.BaseValuePercent, 1.0f));
        wavePower.AddModifier(new CharStatModifier(CharStatsType.WavePower, CharStatModifier.Types.BaseValueAdd, 5.0f));
        wavePower.AddModifier(new CharStatModifier(CharStatsType.WavePower, CharStatModifier.Types.TotalValuePercent, 1.0f));
        wavePower.UpdateModifiers();

        DisplayStatValues();
    }	
    
    void ForEachEnum<T>(Action<T> action)
    {
        if (action != null)
        {
            var statTypes = Enum.GetValues(typeof(T));
            foreach (var statType in statTypes)
                action((T)statType);
        }
    }	

    void DisplayStatValues()
    {
        ForEachEnum<CharStatsType>((statType) =>
        {
            CharStats stat = stats.GetStat((CharStatsType)statType);
            if (stat != null)
            {
                Debug.Log(string.Format("Stat {0}'s value is {1}",
                    stat.StatName, stat.StatValue));
            }
        });
    }
}
