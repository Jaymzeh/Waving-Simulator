using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CharAttributes: CharStatModifiable, IStatScalable, IStatLinkable
{
    private int _statLevelValue;
    private int _statLinkerValue;
    private List<CharStatLinker> _statLinkers;

    public int StatLevelValue
    {
        get { return _statLevelValue; }
    }

    public int StatLinkerValue
    {
        get {
            UpdateLinkers();       
            return _statLinkerValue; }
    }

    public override int StatBaseValue
    {
        get { return base.StatBaseValue + StatLevelValue + StatLinkerValue; }
    }

    public virtual void ScaleStat(int level)
    {
        _statLevelValue = level;
    }

    public void AddLinker(CharStatLinker linker)
    {
        _statLinkers.Add(linker);
    }

    public void ClearLinkers()
    {
        _statLinkers.Clear();
    }

    public void UpdateLinkers()
    {
        _statLinkerValue = 0;
        foreach (CharStatLinker link in _statLinkers)
        {
            _statLinkerValue += link.Value;
        }
    }

    public CharAttributes()
    {
        _statLinkers = new List<CharStatLinker>();
    }
}
