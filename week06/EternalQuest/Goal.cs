using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points; // Note: Stored as string per UML specification

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string statusSymbol = IsComplete() ? "[X]" : "[ ]";
        return $"{statusSymbol} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}