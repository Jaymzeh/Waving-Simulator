using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CharStatModifier
{
    public enum Types
    {
        None,
        BaseValuePercent,
        BaseValueAdd,
        TotalValuePercent,
        TotalValueAdd,
    }

    private Types _type;
    private float _value;
    private CharStatsType _statType;

    public Types Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public CharStatsType StatType
    {
        get { return _statType; }
        set { _statType = value; }
    }

    public CharStatModifier()
    {
        _type = Types.None;
        _value = 0;
        _statType = CharStatsType.None;
    }

    public CharStatModifier(CharStatsType targetStat, Types modType, float value)
    {
        _type = modType;
        _statType = targetStat;
        _value = value;
    }
}