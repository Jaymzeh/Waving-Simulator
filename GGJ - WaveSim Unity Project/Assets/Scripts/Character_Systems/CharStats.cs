using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats {

    private string _statName; //To display name of stat
    private int _statBaseValue; //To display stat value

    public string StatName
    {
        get { return _statName; }
        set { _statName = value; }
    }

    public virtual int StatValue
    {
        get { return _statBaseValue; }
        set { _statBaseValue = value; }
    }

    public virtual int StatBaseValue
    {
        get { return _statBaseValue; }
        set { _statBaseValue = value; }
    }

    public CharStats()
    {
        this.StatName = string.Empty;
        this.StatBaseValue = 0;
    }

    public CharStats(string name, int value)
    {
        this.StatName = name;
        this.StatBaseValue = value;
    }
}
