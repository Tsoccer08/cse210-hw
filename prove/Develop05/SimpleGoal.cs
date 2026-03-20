public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return -1;
        }

        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDisplayInfo()
    {
        string box = _isComplete ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description})";
    }

    public override string GetName()
    {
        return _name;
    }

    public override string GetSaveData()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }

    public void LoadData(bool complete)
    {
        _isComplete = complete;
    }
}