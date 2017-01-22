using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

public class CharStatLinkerBasic : CharStatLinker
{
    private float _ratio;

    public override int Value
    {
        get { return (int)(Stat.StatValue * _ratio); }
    }

    public CharStatLinkerBasic(CharStats stat, float ratio) : base(stat)
    {
        _ratio = ratio;
    }
}
