using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class CharStatLinker
{
    private CharStats _stat;

    public CharStatLinker(CharStats stat)
    {
        _stat = stat;
    }

    public CharStats Stat
    {
        get { return _stat; }
    }

    public abstract int Value { get; }
}