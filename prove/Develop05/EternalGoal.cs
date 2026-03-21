// Represents a goal that never completes and always gives points
public class EternalGoal : Goal
{
    // Constructor passes values to base class
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    // Always returns points when recorded
    public override int RecordEvent()
    {
        return _points;
    }

    // Eternal goals are never complete
    public override bool IsComplete()
    {
        return false;
    }

    // Always shows unchecked box
    public override string GetDisplayInfo()
    {
        return $"[ ] {_name} ({_description})";
    }

    // Returns goal name
    public override string GetName()
    {
        return _name;
    }

    // Returns formatted save data
    public override string GetSaveData()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}