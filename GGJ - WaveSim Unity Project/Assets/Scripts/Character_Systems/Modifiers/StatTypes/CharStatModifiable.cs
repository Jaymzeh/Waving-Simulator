using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class CharStatModifiable : CharStats, IStatModifiable
{
    private List<CharStatModifier> _statMods;
    private int _statModValue;

    public override int StatValue
    {
        get { return base.StatValue * StatModifierValue; }
    }

    public int StatModifierValue
    {
        get { return _statModValue; }
    }

    public CharStatModifiable()
    {
        _statModValue = 0;
        _statMods = new List<CharStatModifier>();
    }

    public void AddModifier(CharStatModifier mod)
    {
        _statMods.Add(mod);
    }

    public void ClearModifiers()
    {
        _statMods.Clear();
    }

    public void UpdateModifiers()
    {
        _statModValue = 0;

        float statModBaseValueAdd = 0;
        float statModBaseValuePercent = 0;
        float statModTotalValueAdd = 0;
        float statModTotalValuePercent = 0;

        foreach (CharStatModifier mod in _statMods)
        {
            switch(mod.Type)
            {
                case CharStatModifier.Types.BaseValueAdd:
                    statModBaseValueAdd += mod.Value;
                    break;
                case CharStatModifier.Types.BaseValuePercent:
                    statModBaseValuePercent += mod.Value;
                    break;
                case CharStatModifier.Types.TotalValueAdd:
                    statModTotalValueAdd += mod.Value;
                    break;
                case CharStatModifier.Types.TotalValuePercent:
                    statModTotalValuePercent += mod.Value;
                    break;
            }
        }

        //Calculating the statModBase values
        _statModValue = (int)((StatBaseValue * statModBaseValuePercent) * statModBaseValueAdd);
        _statModValue += (int)((StatValue * statModTotalValuePercent) * statModTotalValueAdd);
    }
}