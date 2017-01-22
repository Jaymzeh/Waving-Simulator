using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IStatLinkable
{
    int StatLinkerValue { get; }

    void AddLinker(CharStatLinker linker);
    void ClearLinkers();
    void UpdateLinkers();
}
