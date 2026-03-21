// Represents a goal that must be completed multiple times
public class ChecklistGoal : Goal
{
    // Tracks current progress
    private int _current;

    // Target number of completions
    private int _target;

    // Bonus points when fully completed
    private int _bonus;

    // Constructor initializes checklist values
    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _current = 0;
    }

    // Records progress toward completion
    public override int RecordEvent()
    {
        // Prevent further progress if already complete
        if (_current >= _target)
        {
            return -1;
        }

        // Increase completion count
        _current++;

        // If goal just completed, include bonus
        if (_current == _target)
        {
            return _points + _bonus;
        }

        // Otherwise just return normal points
        return _points;
    }

    // Determines if goal is complete
    public override bool IsComplete()
    {
        return _current >= _target;
    }

    // Displays goal with progress
    public override string GetDisplayInfo()
    {
        // Show X only when fully completed
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description}) -- Currently completed: {_current}/{_target}";
    }

    // Returns goal name
    public override string GetName()
    {
        return _name;
    }

    // Converts goal data into savable format
    public override string GetSaveData()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonus}|{_current}|{_target}";
    }

    // Loads saved progress
    public void LoadData(int current, int target)
    {
        _current = current;
        _target = target;
    }
}