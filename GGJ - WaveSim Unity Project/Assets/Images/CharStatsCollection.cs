using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatsCollection
{
    private Dictionary<CharStatsType, CharStats> _statDict;

    public CharStatsCollection()
    {
        _statDict = new Dictionary<CharStatsType, CharStats>();
    }
}
