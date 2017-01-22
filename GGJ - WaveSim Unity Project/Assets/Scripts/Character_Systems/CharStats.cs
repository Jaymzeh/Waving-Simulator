using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats {

    private string _statName; //To display name of stat
    private int _statValue; //To display stat value

    public string StatName
    {
        get { return _statName; }
        set { _statName = value; }
    }

    public int StatValue
    {
        get { return _statValue; }
        set { _statValue = value; }
    }

    public CharStats()
    {
        this.StatName = string.Empty;
        this.StatValue = 0;
    }

    public CharStats(string name, int value)
    {
        this.StatName = name;
        this.StatValue = value;
    }
}
