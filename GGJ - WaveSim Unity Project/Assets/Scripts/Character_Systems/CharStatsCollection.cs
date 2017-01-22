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

    public T GetStat<T>(CharStatsType type) where T : CharStats
    {
        return GetStat(type) as T;
    }

    //Creating the stat in the dictionary
    protected T CreateStat<T>(CharStatsType statType) where T : CharStats
    {
        T stat = System.Activator.CreateInstance<T>();
        _statDict.Add(statType, stat);
        return stat;
    }

    //Get the instance of the stat or create a new one if not available
    protected T CreateOrGetStat<T>(CharStatsType statType) where T :CharStats
    {
        T stat = GetStat<T>(statType);
        if(stat == null)
        {
            stat = CreateStat<T>(statType);
        }
        return stat;
    }
}
