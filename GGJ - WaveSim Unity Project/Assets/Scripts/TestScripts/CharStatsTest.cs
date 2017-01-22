using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharStatsTest : MonoBehaviour {
    private CharStatsCollection stats;

	void Start() {
        stats = new CharDefaultStats();

        var statTypes = Enum.GetValues(typeof(CharStatsType));
        foreach(var statType in statTypes)
        {
            CharStats stat = stats.GetStat((CharStatsType)statType);
            if(stat != null)
            {
                Debug.Log(string.Format("Stat {0}'s value is {1}",
                    stat.StatName, stat.StatValue));
            }
        }
    }		
}
