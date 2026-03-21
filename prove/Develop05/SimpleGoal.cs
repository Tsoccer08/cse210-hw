// Represents a goal that can only be completed once
public class SimpleGoal : Goal
{
    // Tracks whether the goal is completed
    private bool _isComplete;

    // Constructor sets up goal and defaults to not completed
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Records the goal completion
    public override int RecordEvent()
    {
        // Prevent earning points again if already completed
        if (_isComplete)
        {
            return -1;
        }

        // Mark as complete and award points
        _isComplete = true;
        return _points;
    }

    // Returns completion status
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Displays goal with checkbox
    public override string GetDisplayInfo()
    {
        // Show X if complete, otherwise blank
        string box = _isComplete ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description})";
    }

    // Returns only the name of the goal
    public override string GetName()
    {
        return _name;
    }

    // Converts goal data into a savable format
    public override string GetSaveData()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }

    // Loads saved completion state
    public void LoadData(bool complete)
    {
        _isComplete = complete;
    }
}