// Abstract base class that all goal types inherit from
public abstract class Goal
{
    // Shared attributes for all goals
    protected string _name;
    protected string _description;
    protected int _points;

    // Constructor to initialize common goal data
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Method to record progress on a goal
    public abstract int RecordEvent();

    // Determines if the goal is complete
    public abstract bool IsComplete();

    // Returns formatted display information for listing goals
    public abstract string GetDisplayInfo();

    // Returns just the goal name (used when selecting goals)
    public abstract string GetName();

    // Returns formatted string for saving to file
    public abstract string GetSaveData();
}