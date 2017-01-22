using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IStatModifiable
{
    int StatModifierValue { get; }

    void AddModifier(CharStatModifier mod);
    void ClearModifiers();
    void UpdateModifiers();

}

