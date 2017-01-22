using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CharAttributes: CharStatModifiable, IStatScalable
{
    private int _statLevelValue;

    public int StatLevelValue
    {
        get { return _statLevelValue; }
    }

    public override int StatBaseValue
    {
        get { return base.StatBaseValue + StatLevelValue; }
    }

    public void ScaleStat(int level)
    {
        _statLevelValue = level;
    }
}
