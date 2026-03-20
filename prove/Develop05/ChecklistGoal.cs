public class ChecklistGoal : Goal
{
    private int _current;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _current = 0;
    }

    public override int RecordEvent()
    {
        if (_current >= _target)
        {
            return -1;
        }

        _current++;

        if (_current == _target)
        {
            return _points + _bonus;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _current >= _target;
    }

    public override string GetDisplayInfo()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description}) -- Currently completed: {_current}/{_target}";
    }

    public override string GetName()
    {
        return _name;
    }

    public override string GetSaveData()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonus}|{_current}|{_target}";
    }

    public void LoadData(int current, int target)
    {
        _current = current;
        _target = target;
    }
}