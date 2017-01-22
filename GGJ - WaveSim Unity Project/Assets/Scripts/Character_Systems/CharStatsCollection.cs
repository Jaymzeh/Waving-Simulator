using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatsCollection
{
    private Dictionary<CharStatsType, CharStats> _statDict;

    public CharStatsCollection()
    {
        _statDict = new Dictionary<CharStatsType, CharStats>();
        ConfigureStats();
    }

    protected virtual void ConfigureStats()
    {

    }

    //Checking to see if the stat type is in the Dictionary or not
    public bool Contains(CharStatsType statType)
    {
        return _statDict.ContainsKey(statType);
    }

    //Getting the stat from the dictionary
    public CharStats GetStat(CharStatsType statType)
    {
        if(Contains(statType))
        {
            return _statDict[statType];
        }
        return null;
    }

    //Creating the stat in the dictionary
    protected CharStats CreateStat(CharStatsType statType)
    {
        CharStats stat = new CharStats();
        _statDict.Add(statType, stat);
        return stat;
    }

    //Get the instance of the stat or create a new one if not available
    protected CharStats CreateOrGetStat(CharStatsType statType)
    {
        CharStats stat = GetStat(statType);
        if(stat == null)
        {
            stat = CreateStat(statType);
        }
        return stat;
    }
}
